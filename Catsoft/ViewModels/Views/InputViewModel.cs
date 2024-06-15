namespace App.ViewModels.Views
{
    public class InputViewModel(string labelTag, string propertyName, string value, bool enabled = true)
    {
        public string LabelTag { get; set; } = labelTag;

        public string PropertyName { get; set; } = propertyName;
        public string Value { get; set; } = value;

        public InputType Type { get; set; } = InputType.Text;

        public bool Enabled { get; set; } = enabled;
    }

    public enum InputType
    {
        Text,
        Hidden,
        Submit,
    }
}