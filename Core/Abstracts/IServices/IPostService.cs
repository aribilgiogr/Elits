using Core.Concretes.DTOs.Post;

namespace Core.Abstracts.IServices
{
    public interface IPostService
    {
        Task<PostDto> GetByIdAsync(Guid id);
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto> CreateAsync(CreatePostDto dto);
        Task UpdateAsync(Guid id, UpdatePostDto dto);
        Task DeleteAsync(Guid id);
    }
}
