using App.Models.Pages;

namespace App.ViewModels.Common
{
    public class CommonPageViewModel<T> : CommonPageViewModel
    {
        public T Page { get; set; }

        public CommonPageViewModel()
        {
            
        }

        public CommonPageViewModel(T page, HeaderViewModel headerViewModel, FooterViewModel footerViewModel)
        {
            HeaderViewModel = headerViewModel;
            FooterViewModel = footerViewModel;
            Page = page;
        }

        public override IMetaInfo GetMetaPage()
        {
            return Page as IMetaInfo;
        }
    }
}