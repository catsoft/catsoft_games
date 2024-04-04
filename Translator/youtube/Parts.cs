namespace Translator.youtube
{
    public static class Parts
    {
        public static Dictionary<string, string> LanguageMap = new()
        {
            { "ar", "Arabic" },
            { "bn", "Bangla" },
            { "zh-TW", "Chinese (Traditional)" },
            { "en", "English" },
            { "fr", "French" },
            { "de", "German" },
            { "hi", "Hindi" },
            { "id", "Indonesian" },
            { "it", "Italian" },
            { "ja", "Japanese" },
            { "ko", "Korean" },
            { "pl", "Polish" },
            { "pt", "Portuguese" },
            { "ru", "Russian" },
            { "es", "Spanish" },
            { "th", "Thai" }
        };

        public static List<string> Caption { get; set; } = new() { "id", "snippet" };


        public static List<string> Languages { get; set; } = new() { "snippet" };

        public static List<string> Video { get; set; } = new()
        {
            "id", "snippet"
        };

        public static List<string> VideoLocalization { get; set; } = new()
        {
            "id", "localizations",
            // "contentDetails",
            // "fileDetails",
            // "liveStreamingDetails",
            // "player",
            // "processingDetails",
            // "recordingDetails",
            "snippet"
            // "statistics",
            // "status",
            // "suggestions",
            // "topicDetails",
        };

        public static List<string> VideoUpdateLocalization { get; set; } = new() { "snippet", "localizations" };

        public static List<string> Countries { get; set; } = LanguageMap.Keys.ToList();
    }
}