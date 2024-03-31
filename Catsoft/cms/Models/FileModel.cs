using App.cms.Controllers.Attributes;
using App.Models;
using App.Models.Accounting;
using System;

namespace App.cms.Models
{
    public class FileModel : Entity<FileModel>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string FileType { get; set; }


        [Show(false, false, false, false)]
        public Guid? TransactionId { get; set; }

        [Show(false, false, false, false)]
        public TransactionModel TransactionModel { get; set; }
    }
}
