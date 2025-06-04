using Core.Abstracts.Bases;
using Core.Concretes.DTOs.Comment;

namespace Core.Concretes.DTOs.Post
{
    public class PostDto : PostBaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid MemberId { get; set; }
        public string MemberUserName { get; set; } = string.Empty;
        public string? MemberProfilePictureUrl { get; set; }
        public int CommentCount { get; set; } = 0;
        public IEnumerable<CommentDto> Comments { get; set; } = [];
        public int LikeCount { get; set; } = 0;
    }
}
