using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Post> Posts { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<PostLike> PostLikes { get; set; } = [];
        public ICollection<Follower> Following { get; set; } = [];
        public ICollection<Follower> Followers { get; set; } = [];
        public ICollection<DirectMessage> SentMessages { get; set; } = [];
        public ICollection<DirectMessage> ReceivedMessages { get; set; } = [];
        public ICollection<Notification> Notifications { get; set; } = [];
    }
}