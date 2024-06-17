namespace App.ViewModels.Views
{
    public class YoutubeViewModel(string url, bool autoplay = true) {
        public string Url { get; } = url;
        public bool AutoPlay { get; } = autoplay;
    }
}