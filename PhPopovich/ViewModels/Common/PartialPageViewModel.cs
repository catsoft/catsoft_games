namespace App.ViewModels.Common
{
    public class PartialPageViewModel<T>
    {
        public T Page { get; set; }

        public PartialPageViewModel()
        {

        }

        public PartialPageViewModel(T page)
        {
            Page = page;
        }
    }
}