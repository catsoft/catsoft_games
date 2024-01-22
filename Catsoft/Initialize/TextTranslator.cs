using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Translator.gpt;

namespace App.Initialize
{
    public class TextTranslator(CatsoftContext catsoftContext)
    {
        private GPTRealApi _gptRealApi = new GPTRealApi();

        public async Task Translate()
        {
            var textResources = catsoftContext.TextResourceModels.Include(w => w.Values);
            var languages = Enum.GetValues(typeof(TextLanguage)).Cast<TextLanguage>().ToList();
            foreach (var textResource in textResources)
            {
                var values = textResource.Values?.ToList() ?? new List<TextResourceValueModel>();

                foreach (var language in languages)
                {
                    if (values.All(w => w.Language != language))
                    {
                        var newValue = new TextResourceValueModel
                        {
                            Language = language,
                            Value = await TranslateText(textResource, language)
                        };
                        catsoftContext.Add(newValue);
                        await catsoftContext.SaveChangesAsync();
                    }
                }
            }

            await catsoftContext.SaveChangesAsync();
        }

        public async Task ForceTranslateLanguage(TextLanguage forcedLanguage)
        {
            var textResources = catsoftContext.TextResourceModels.Include(w => w.Values).ToList();
            foreach (var textResource in textResources)
            {
                var value = (textResource.Values?.ToList() ?? new List<TextResourceValueModel>()).FirstOrDefault(w => w.Language == forcedLanguage);

                var newValue = await TranslateText(textResource, forcedLanguage);

                if (value == null)
                {
                    value = new TextResourceValueModel()
                    {
                        Language = forcedLanguage,
                        Value = newValue,
                        TextResourceModelId = textResource.Id
                    };
                    catsoftContext.Add(value);
                }
                else
                {
                    value.Value = newValue;
                    catsoftContext.Update(value);
                }
                await catsoftContext.SaveChangesAsync();
            }

            await catsoftContext.SaveChangesAsync();
        }

        public void GenerateDefaultResources()
        {
            var textResources = catsoftContext.TextResourceModels.Include(w => w.Values);
            var languages = new List<TextLanguage>()
            {
                TextLanguage.English,
            };
            foreach (var textResource in textResources)
            {
                var values = textResource.Values?.ToList() ?? new List<TextResourceValueModel>();

                foreach (var language in languages)
                {
                    if (values.All(w => w.Language != language))
                    {
                        var newValue = new TextResourceValueModel
                        {
                            Language = language,
                            Value = textResource.Tag,
                            TextResourceModelId = textResource.Id
                        };
                        catsoftContext.Add(newValue);
                        catsoftContext.SaveChanges();
                    }
                }
            }

            catsoftContext.SaveChanges();
        }

        private async Task<string> TranslateText(TextResourceModel textResource, TextLanguage language)
        {
            return await _gptRealApi.Translate(language.ToString(), textResource.Tag);
        }
    }
}