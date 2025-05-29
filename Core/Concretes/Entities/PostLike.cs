namespace Core.Concretes.Entities
{
    public class PostLike
    {
        public Guid Id { get; set; }

        public Guid MemberId { get; set; }
        public ApplicationUser? Member { get; set; }

        public Guid PostId { get; set; }
        public Post? Post { get; set; }
    }
}