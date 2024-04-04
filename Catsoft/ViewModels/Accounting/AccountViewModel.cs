using App.Models.Accounting;

namespace App.ViewModels.Accounting
{
    public class AccountViewModel(AccountModel accountModel)
    {
        public AccountModel AccountModel { get; set; } = accountModel;
    }
}