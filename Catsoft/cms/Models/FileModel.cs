using System;
using System.ComponentModel.DataAnnotations.Schema;
using App.cms.Controllers.Attributes;
using App.Models.Accounting;

namespace App.cms.Models
{
    public class FileModel : Entity<FileModel>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string FileType { get; set; }


        [Show(false, false, false, false)] public Guid? TransactionModelId { get; set; }

        [ForeignKey("TransactionModelId")]
        [Show(false, false, false, false)] public TransactionModel TransactionModel { get; set; }
        
    }
}