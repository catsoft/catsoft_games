using System.Collections.Generic;

namespace App.ViewModels.Views
{
    public class SelectorViewModel(string label, string value, List<KeyValueViewModel> options, bool multipleSelection)
    {
        public string Label { get; set; } = label;
        
        public string SelectedValue { get; set; } = value;
        
        public List<KeyValueViewModel> Options { get; set; } = options;

        public bool MultipleSelection { get; set; } = multipleSelection;

        public bool DefaultSelection { get; set; } = true;
        
        public string OnChangeScript { get; set; }

        public bool WithDefaultValue { get; set; } = true;
        
        public bool Enabled { get; set; } = true;
    }
}