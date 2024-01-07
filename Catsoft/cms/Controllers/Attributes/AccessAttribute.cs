namespace App.cms.Controllers.Attributes
{
    /// <summary>
    /// Показывает нужно ли отображать это свойство в списке\при детализации\редактировании
    /// </summary>
    public class AccessAttribute(bool onDetails = true, bool onCreate = true, bool onEdit = true, bool onDelete = true)
        : System.Attribute
    {
        public bool OnDetails { get; set; } = onDetails;
        public bool OnCreate { get; set; } = onCreate;
        public bool OnEdit { get; set; } = onEdit;
        public bool OnDelete { get; set; } = onDelete;
    }
}
