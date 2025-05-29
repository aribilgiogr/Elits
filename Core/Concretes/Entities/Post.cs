namespace Core.Concretes.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public required string Content { get; set; }
        public string? AttachedImageUrl { get; set; }

        public Guid MemberId { get; set; }
        public ApplicationUser? Member { get; set; }

        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<PostLike> Likes { get; set; } = [];
    }
}