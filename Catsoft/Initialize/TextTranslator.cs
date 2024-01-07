using System;
using System.Collections.Generic;
using System.Linq;
using App.cms.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Initialize
{
    public class TextTranslator(CatsoftContext catsoftContext)
    {
        public void Translate()
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
                            Value = TranslateText(textResource, language)
                        };
                        catsoftContext.Add(newValue);
                        catsoftContext.SaveChanges();
                    }
                }
            }

            catsoftContext.SaveChanges();
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

        private static string TranslateText(TextResourceModel textResource, TextLanguage language)
        {
            return textResource.Tag;
        }
    }
}