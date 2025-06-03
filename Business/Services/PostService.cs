using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Post;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PostDto> CreateAsync(CreatePostDto dto)
        {
            var post = mapper.Map<Post>(dto);
            await unitOfWork.PostRepository.CreateOneAsync(post);
            await unitOfWork.CommitAsync();
            return mapper.Map<PostDto>(post);
        }

        public async Task DeleteAsync(Guid id)
        {
            await unitOfWork.PostRepository.DeleteOneAsync(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            var posts = await unitOfWork.PostRepository.FindManyAsync(null, "Member", "Comments", "Likes");
            return mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> GetByIdAsync(Guid id)
        {
            var post = await unitOfWork.PostRepository.FindOneByKeyAsync(id);
            return mapper.Map<PostDto>(post);
        }

        public async Task UpdateAsync(Guid id, UpdatePostDto dto)
        {
            var post = await unitOfWork.PostRepository.FindOneByKeyAsync(id);
            //Mapper: Eğer iki nesnede sadece farklı olanları yer değiştirmek istersek Map için generic (T) yazılmaz.
            mapper.Map(dto, post); //in-place (yerinde) değiştirme. post = dto
            await unitOfWork.CommitAsync();
        }
    }
}
