namespace Core.Concretes.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public required string Content { get; set; }

        public Guid MemberId { get; set; }
        public ApplicationUser? Member { get; set; }

        public Guid PostId { get; set; }
        public Post? Post { get; set; }
    }
}