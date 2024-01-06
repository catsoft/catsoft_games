namespace App.CMS.Controllers.Attributes
{
    /// <summary>
    /// Показывает нужно ли отображать это свойство в списке\при детализации\редактировании
    /// </summary>
    public class ShowAttribute(bool showInList = true, bool showInDetails = true, bool showInEdit = true,
            bool showInCreate = true)
        : System.Attribute
    {
        public bool ShowInList { get; set; } = showInList;
        public bool ShowInDetails { get; set; } = showInDetails;
        public bool ShowInEdit { get; set; } = showInEdit;
        public bool ShowInCreate { get; set; } = showInCreate;
    }
}
