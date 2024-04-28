using System;

namespace App.ViewModels.Views
{
    public class DateViewModel(string nameTag, DateOnly? date)
    {
        public string NameTag { get; set; } = nameTag;

        public DateOnly? Date { get; set; } = date;
    }
}