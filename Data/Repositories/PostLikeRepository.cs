using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories
{
    public class PostLikeRepository : Repository<PostLike>, IPostLikeRepository
    {
        public PostLikeRepository(ApplicationDbContext context) : base(context) { }
    }
}
