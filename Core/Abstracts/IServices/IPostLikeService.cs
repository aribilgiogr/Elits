using Core.Concretes.DTOs.PostLike;

namespace Core.Abstracts.IServices
{
    public interface IPostLikeService
    {
        Task CreateAsync(CreatePostLikeDto dto);
        Task DeleteAsync(Guid id);
        Task<bool> IsLikedByUserAsync(Guid postId, Guid userId);
    }
}
