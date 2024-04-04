namespace App.ViewModels.Views
{
    public class KeyValueViewModel(string label, string value)
    {
        public string Value { get; set; } = value;

        public string Label { get; set; } = label;
    }
}