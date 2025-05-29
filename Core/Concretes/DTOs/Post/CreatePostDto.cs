using Core.Abstracts.Bases;

namespace Core.Concretes.DTOs.Post
{
    public class CreatePostDto : PostBaseDto
    {
        public Guid MemberId { get; set; }
    }
}
