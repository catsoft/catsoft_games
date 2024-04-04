namespace App.cms.ViewModels
{
    public class PaginationViewModel(string url, int currentPage, int maxPage)
    {
        public string Url { get; set; } = url;
        public int MaxPage { get; set; } = maxPage;
        public int CurrentPage { get; set; } = currentPage;
    }
}