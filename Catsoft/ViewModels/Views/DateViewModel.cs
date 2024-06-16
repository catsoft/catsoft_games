using System;

namespace App.ViewModels.Views
{
    public class DateViewModel(string nameTag, DateOnly? date, string onChangeScript)
    {
        public string NameTag { get; set; } = nameTag;

        public DateOnly? Date { get; set; } = date;

        public bool Enabled { get; set; } = true;
        
        public string OnChangeOnChangeScript { get; set; } = onChangeScript;
    }
}