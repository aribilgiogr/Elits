namespace Core.Concretes.Entities
{
    public class Follower
    {
        public DateTime FollowedAt { get; set; } = DateTime.Now;

        public Guid FollowerMemberId { get; set; }
        public ApplicationUser? FollowerMember { get; set; }

        public Guid FollowedMemberId { get; set; }
        public ApplicationUser? FollowedMember { get; set; }
    }
}