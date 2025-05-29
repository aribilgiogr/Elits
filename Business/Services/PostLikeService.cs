using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.PostLike;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class PostLikeService : IPostLikeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PostLikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreatePostLikeDto dto)
        {
            var like = mapper.Map<PostLike>(dto);
            await unitOfWork.PostLikeRepository.CreateOneAsync(like);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await unitOfWork.PostLikeRepository.DeleteOneAsync(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> IsLikedByUserAsync(Guid postId, Guid userId)
        {
            return await unitOfWork.PostLikeRepository.AnyAsync(x => x.PostId.Equals(postId) && x.MemberId.Equals(userId));
        }
    }
}
