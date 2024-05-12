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
                    var chunkText = "Translate it to " + language + " without adding anything else and saving line breaks and other formatting"
                                    + ":\n\n" + chunkString;
                    var result = await DoRequest(chunkText);

                    var content = result.Choices.FirstOrDefault()?.Message.TextContent ?? "";

                    output.Append(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

            var content = result.Choices.FirstOrDefault()?.Message.TextContent ?? "";

            return content;
        }
        
        private async Task<ChatResult> DoRequest(string text)
        {
            var messages = new List<ChatMessage> { new(ChatMessageRole.User, text) };
            var model = new Model(Model.ChatGPTTurbo);
            var temperature = 0;
            var result = await _api.Chat.CreateChatCompletionAsync(messages, model, temperature);
            return result;
        }
    }
}