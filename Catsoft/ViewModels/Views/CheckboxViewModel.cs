namespace App.ViewModels.Views
{
    public class CheckboxViewModel(string nameTag, bool isChecked)
    {
        public string NameTag { get; set; } = nameTag;

        public bool Checked { get; set; } = isChecked;
    }
}