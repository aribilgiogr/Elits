using Core.Concretes.DTOs.Comment;

namespace Core.Abstracts.IServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetByPostIdAsync(Guid postId);
        Task CreateAsync(CreateCommentDto dto);
        Task UpdateAsync(Guid id, UpdateCommentDto dto);
        Task DeleteAsync(Guid id);
    }
}
