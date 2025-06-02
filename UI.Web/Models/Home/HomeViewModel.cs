using Core.Concretes.DTOs.Post;

namespace UI.Web.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<PostDto> Posts { get; set; } = [];
    }
}
