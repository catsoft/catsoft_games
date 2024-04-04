namespace App.ViewModels.Common
{
    public class PartialPageViewModel<T>
    {
        public PartialPageViewModel()
        {
        }

        public PartialPageViewModel(T page)
        {
            Page = page;
        }

        public T Page { get; set; }
    }
}