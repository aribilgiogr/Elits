using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Follower;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FollowerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task FollowAsync(CreateFollowerDto dto)
        {
            if (dto.FollowedMemberId == dto.FollowerMemberId || await IsFollowingAsync(dto)) return;

            var follower = mapper.Map<Follower>(dto);
            await unitOfWork.FollowerRepository.CreateOneAsync(follower);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<FollowerDto>> GetFollowersAsync(Guid memberId)
        {
            var followers = await unitOfWork.FollowerRepository.FindManyWithOrderedAsync(x => x.FollowedAt, false, x => x.FollowedMemberId == memberId);

            return mapper.Map<IEnumerable<FollowerDto>>(followers);
        }

        public async Task<IEnumerable<FollowerDto>> GetFollowingAsync(Guid memberId)
        {
            var following = await unitOfWork.FollowerRepository.FindManyWithOrderedAsync(x => x.FollowedAt, false, x => x.FollowerMemberId == memberId);

            return mapper.Map<IEnumerable<FollowerDto>>(following);
        }

        public async Task<bool> IsFollowingAsync(CreateFollowerDto dto)
        {
            return await unitOfWork.FollowerRepository.AnyAsync(f => f.FollowerMemberId == dto.FollowerMemberId && f.FollowedMemberId == dto.FollowedMemberId);
        }

        public async Task UnfollowAsync(CreateFollowerDto dto)
        {
            var relation = await unitOfWork.FollowerRepository.FindFirstAsync(f => f.FollowerMemberId == dto.FollowerMemberId && f.FollowedMemberId == dto.FollowedMemberId);

            if (relation != null)
            {
                await unitOfWork.FollowerRepository.DeleteOneAsync(relation);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
