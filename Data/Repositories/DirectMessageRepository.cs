using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories
{
    public class DirectMessageRepository : Repository<DirectMessage>, IDirectMessageRepository
    {
        public DirectMessageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
