namespace App.ViewModels.Common
{
    public class SimplePageViewModel : CommonPageViewModel
    {
        public SimplePageViewModel()
        {
        }

        public SimplePageViewModel(HeaderViewModel headerViewModel, FooterViewModel footerViewModel)
        {
            HeaderViewModel = headerViewModel;
            FooterViewModel = footerViewModel;
        }
    }
}