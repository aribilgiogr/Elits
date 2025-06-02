namespace UI.Web.Models.Home
{
    public class NewPostViewModel
    {
        public required string Content { get; set; }
        public FormFile? AttachedImage { get; set; }
        public string? AttachedImageUrl { get; set; }
        public Guid MemberId { get; set; }
    }
}
