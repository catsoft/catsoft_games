namespace App.ViewModels.Views
{
    public class ButtonViewModel(string labelTag, string action, string controller, string method) {
        public string LabelTag { get; } = labelTag;
        public string Action { get; } = action;
        public string Controller { get; } = controller;
        public string Method { get; } = method;
    }
}