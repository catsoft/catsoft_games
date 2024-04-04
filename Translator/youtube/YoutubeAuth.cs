namespace Translator.youtube
{
    internal class YoutubeAuth
    {
        public string ApiKey { get; set; }
        public string ClientSecret { get; set; }
        public string CliendId { get; set; }

        public static YoutubeAuth GetYoutubeAutoTranslate()
        {
            return new YoutubeAuth
            {
                ApiKey = "AIzaSyDKFs2EWOjdzotSMeZpPGyQygPmUBIgwm4",
                ClientSecret = "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",
                CliendId = "937351979898-h7064jc1ucbjpivpnkqkc79bdoobs7nc.apps.googleusercontent.com"
            };
        }

        public static YoutubeAuth GetKeepPushing()
        {
            return new YoutubeAuth
            {
                ApiKey = "AIzaSyDiuwLpy69cDeRZCX454ZPSup3QKP3g51A",
                ClientSecret = "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",
                CliendId = "969908950997-11bdlf2leponvh45vj0t53ts29m77rn1.apps.googleusercontent.com"
            };
        }

        public static YoutubeAuth GetThird()
        {
            return new YoutubeAuth
            {
                ApiKey = "AIzaSyBy6wHNC-vpfpYtUC_aDI2Oo92zbzVZj-A",
                ClientSecret = "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",
                CliendId = "193355046616-eltsg3fk61figcsnkh3ukiobvlv6uuo0.apps.googleusercontent.com"
            };
        }

        public static YoutubeAuth GetFour()
        {
            return new YoutubeAuth
            {
                ApiKey = "AIzaSyDxlOw7eeHZFRHO14ONBK2ryqRH04PEAe8",
                ClientSecret = "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",
                CliendId = "654257168091-3k4iic5g4nae67ss08ga1r6k9535fut9.apps.googleusercontent.com"
            };
        }

        public static YoutubeAuth GetFive()
        {
            return new YoutubeAuth
            {
                ApiKey = "AIzaSyAQlq5QjGkWZuCriJk-j8M5PcQfhDQ8qbw",
                ClientSecret = "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",
                CliendId = "401448010245-ogfs2jrkip9r52qtr7c4nh2a4s409j16.apps.googleusercontent.com"
            };
        }

        public static YoutubeAuth GetSix()
        {
            return new YoutubeAuth
            {
                ApiKey = "AIzaSyAWGyOw88HG7DHmljhRso7TUvZ3JHd9o-k",
                ClientSecret = "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",
                CliendId = "321260564749-lei23a3sfhh5jtpf3l5kh3vrq9omd65t.apps.googleusercontent.com"
            };
        }
    }
}