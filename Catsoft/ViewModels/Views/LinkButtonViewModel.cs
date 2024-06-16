namespace App.ViewModels.Views
{
    public class LinkButtonViewModel(string labelTag, string action, string controller) {
        public string LabelTag { get; } = labelTag;
        public string Action { get; } = action;
        public string Controller { get; } = controller;
    }
}