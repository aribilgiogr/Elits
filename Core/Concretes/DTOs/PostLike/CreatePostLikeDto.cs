namespace Core.Concretes.DTOs.PostLike
{
    public class CreatePostLikeDto
    {
        public Guid MemberId { get; set; }
        public Guid PostId { get; set; }
    }
}
