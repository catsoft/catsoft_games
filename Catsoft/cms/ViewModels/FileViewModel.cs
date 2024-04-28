using System;

namespace App.cms.ViewModels
{
    public class FileViewModel
    {
        public string PropertyName { get; set; }

        public Guid? FileId { get; set; }

        public string Url { get; set; }
    }
}