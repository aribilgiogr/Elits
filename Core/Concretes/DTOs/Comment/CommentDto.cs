namespace Core.Concretes.DTOs.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PostId { get; set; }
        public Guid MemberId { get; set; }
        public string MemberUserName { get; set; } = string.Empty;
        public string? MemberProfilePictureUrl { get; set; }
    }
}
