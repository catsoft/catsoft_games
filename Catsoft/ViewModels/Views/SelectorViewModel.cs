using System.Collections.Generic;

namespace App.ViewModels.Views
{
    public class SelectorViewModel(string label, string value, List<KeyValueViewModel> options)
    {
        public string Label { get; set; } = label;
        
        public string SelectedValue { get; set; } = value;
        
        public List<KeyValueViewModel> Options { get; set; } = options;
    }
}