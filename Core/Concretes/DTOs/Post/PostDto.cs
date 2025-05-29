using Core.Abstracts.Bases;

namespace Core.Concretes.DTOs.Post
{
    public class PostDto : PostBaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid MemberId { get; set; }
    }
}
