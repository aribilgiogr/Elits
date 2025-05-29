namespace Core.Concretes.DTOs.Comment
{
    public class CreateCommentDto
    {
        public required string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid MemberId { get; set; }
    }
}
