using System.Collections.Generic;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Accounting
{
    [Access]
    public class AccountModel : Entity<AccountModel>
    {
        public override string Title => Name;


        public string Name { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }


        [OneTwoMany("AccountFromId")]
        [Show(false, true, false, false)]
        [ShowTitle]
        public List<TransactionModel> TransactionFromModels { get; set; }


        [OneTwoMany("AccountToId")]
        [Show(false, true, false, false)]
        [ShowTitle]
        public List<TransactionModel> TransactionToModels { get; set; }
    }
}