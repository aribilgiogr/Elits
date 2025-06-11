namespace Core.Concretes.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public required string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Guid MemberId { get; set; } // Hedef kullanıcı
        public ApplicationUser? Member { get; set; }

        public bool IsRead { get; set; } = false;
        public required string Type { get; set; } // "like", "comment", "follow", "dm" gibi
        public Guid? RelatedPostId { get; set; }
        public Guid? RelatedCommentId { get; set; }
    }


}
