using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories
{
    public class FollowerRepository : Repository<Follower>, IFollowerRepository
    {
        public FollowerRepository(ApplicationDbContext context) : base(context) { }
    }
}
