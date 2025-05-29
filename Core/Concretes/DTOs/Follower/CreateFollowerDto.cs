namespace Core.Concretes.DTOs.Follower
{
    public class CreateFollowerDto
    {
        public Guid FollowerMemberId { get; set; }
        public Guid FollowedMemberId { get; set; }
    }
}
