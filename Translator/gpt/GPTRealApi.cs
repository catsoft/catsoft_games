using System.Text;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Translator.models;

namespace Translator.gpt
{
    public class GPTRealApi
    {
        private static readonly int _chunkSize = 2000;

        private readonly OpenAIAPI _api = new(GptCreds.ApiKey);


        public GPTRealApi()
        {
            var gpt4Turbo = new Model("gpt-4-1106-preview");

            var requst = new ChatRequest
            {
                Model = gpt4Turbo,
                Temperature = 0
            };
            _api.Chat.DefaultChatRequestArgs = requst;
        }

        public List<SubtitleModel> GenerateSubs(string text)
        {
            var parsedModule = new List<SubtitleModel>();
            var bigLines = text.Trim().Split("\n\n");
            foreach (var bigLine in bigLines)
            {
                var splited = bigLine.Trim().Split("\n");
                var time = splited[0];
                var content = string.Join("", splited.Skip(1));

                var model = new SubtitleModel
                {
                    Time = time,
                    Content = content
                };
                parsedModule.Add(model);
            }

            return parsedModule;
        }

        public async Task<string> TranslateSubs(string language, string text, List<SubtitleModel> subs)
        {
            var translatedText = await Translate(language, text);
            Console.WriteLine("Translated text:" + translatedText);
            var translatedLines = translatedText.Split('\n').ToArray();

            var translatedSubs = subs.Select((i, j) => new SubtitleModel
            {
                Time = i.Time,
                Content = j < translatedLines.Length ? translatedLines[j] : ""
            });
            var output = string.Join("", translatedSubs.Select(i => i.ToString()));

            return output;
        }


        public async Task<string> Translate(string language, string text)
        {
            var split = text
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / _chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();

            var output = new StringBuilder();

            foreach (var oneChunk in split)
            {
                try
                {
                    var chunkString = string.Join("", oneChunk);
                    var chunkText = "There is subs. Translate it to " + language +
                                    " without adding anything else and saving line breaks. If it hashtag translate it only to " +
                                    language + ":" +
                                    ":\n\n" + chunkString;
                    var result = await _api.Chat.CreateChatCompletionAsync(chunkText);

                    var content = result.Choices.FirstOrDefault()?.Message.Content ?? "";

                    output.Append(content);
                }
                catch (Exception ex)
                {
                    //todo show error
                    // MessageBox.Show(ex.Message);
                }
            }

            return output.ToString();
        }

        public async Task<string> GenerateHashtags(string title, string language = "ru", int count = 50)
        {
            var chunkText = "Generate " + count + " hashtags in " + language +
                            " without adding anything else in one row. Hashtags should be only in " + language +
                            ":\n\n" + title;
            var result = await _api.Chat.CreateChatCompletionAsync(chunkText);

            var content = result.Choices.FirstOrDefault()?.Message.Content ?? "";

            return content;
        }
    }
}