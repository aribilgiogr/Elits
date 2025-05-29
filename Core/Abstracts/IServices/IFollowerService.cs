using Core.Concretes.DTOs.Follower;

namespace Core.Abstracts.IServices
{
    public interface IFollowerService
    {
        Task FollowAsync(CreateFollowerDto dto);
        Task UnfollowAsync(CreateFollowerDto dto);
        Task<IEnumerable<FollowerDto>> GetFollowersAsync(Guid memberId);
        Task<IEnumerable<FollowerDto>> GetFollowingAsync(Guid memberId);
        Task<bool> IsFollowingAsync(CreateFollowerDto dto);
    }
}
