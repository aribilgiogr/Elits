using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Comment;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateCommentDto dto)
        {
            var comment = mapper.Map<Comment>(dto);
            await unitOfWork.CommentRepository.CreateOneAsync(comment);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await unitOfWork.CommentRepository.DeleteOneAsync(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetByPostIdAsync(Guid postId)
        {
            var comments = await unitOfWork.CommentRepository.FindManyWithOrderedAsync(x => x.CreatedAt, false, x => x.PostId.Equals(postId));
            return mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task UpdateAsync(Guid id, UpdateCommentDto dto)
        {
            var comment = await unitOfWork.CommentRepository.FindOneByKeyAsync(id);
            mapper.Map(dto, comment);
            await unitOfWork.CommitAsync();
        }
    }
}
