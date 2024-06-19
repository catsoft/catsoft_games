namespace App.ViewModels.Views
{
    public class ButtonViewModel(string labelTag, string action, string controller, string method, bool withForm = true, Style style = Style.Brand) {
        public string LabelTag { get; } = labelTag;
        public string Action { get; } = action;
        public string Controller { get; } = controller;
        public string Method { get; } = method;
        public bool WithForm { get; } = withForm;

        public Style Style { get; set; } = style;
    }

    public enum Style
    {
        Brand,
        Black
    }
    
}