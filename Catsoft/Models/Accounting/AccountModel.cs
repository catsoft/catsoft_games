using App.cms.Controllers.Attributes;
using App.cms.Models;
using System.Collections.Generic;

namespace App.Models.Accounting
{
    [Access]
    public class AccountModel : Entity<AccountModel>
    {
        public override string Title { get => Name; }


        public string Name { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }


        [OneTwoMany("AccountFromId")]
        [Show(false, false, false, false)]
        [ShowTitle]
        public List<TransactionModel> TransactionFromModels { get; set; }


        [OneTwoMany("AccountToId")]
        [Show(false, false, false, false)]
        [ShowTitle]
        public List<TransactionModel> TransactionToModels { get; set; }
    }
}