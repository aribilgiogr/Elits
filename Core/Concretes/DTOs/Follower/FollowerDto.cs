namespace Core.Concretes.DTOs.Follower
{
    public class FollowerDto
    {
        public Guid FollowerMemberId { get; set; }
        public Guid FollowedMemberId { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}
