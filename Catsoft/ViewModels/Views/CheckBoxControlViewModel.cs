namespace App.ViewModels.Views
{
    public class CheckBoxControlViewModel(string labelTag, string propertyName, bool value, string showId)
    {
        public string LabelTag { get; set; } = labelTag;

        public string PropertyName { get; set; } = propertyName;
        
        public bool Value { get; set; } = value;

        public string ShowId { get; set; } = showId;
    }
}