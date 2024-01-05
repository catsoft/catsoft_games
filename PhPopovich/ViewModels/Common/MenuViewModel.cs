using App.Models;

namespace App.ViewModels.Common
{
    public class MenuViewModel
    {
        public string Title { get; set; }

        public string Href { get; set; }

        public bool IsCurrent { get; set; }

        public Menu Menu { get; set; }

        public MenuViewModel()
        {
            
        }

        public MenuViewModel(string title, string href, Menu menu, bool isCurrent = false)
        {
            Title = title;
            Menu = menu;
            Href = href;
            IsCurrent = isCurrent;
        }
    }
}