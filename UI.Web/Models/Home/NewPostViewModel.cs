namespace UI.Web.Models.Home
{
    public class NewPostViewModel
    {
        public string Content { get; set; } = string.Empty;
        public IFormFile? AttachedImage { get; set; }
        public string? AttachedImageUrl { get; set; }
        public Guid MemberId { get; set; }
    }
}
