using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private ICommentRepository? commentRepository;
        public ICommentRepository CommentRepository => commentRepository ??= new CommentRepository(context);

        private IPostRepository? postRepository;
        public IPostRepository PostRepository => postRepository ??= new PostRepository(context);

        private IPostLikeRepository? postLikeRepository;
        public IPostLikeRepository PostLikeRepository => postLikeRepository ??= new PostLikeRepository(context);

        private IFollowerRepository? followerRepository;
        public IFollowerRepository FollowerRepository => followerRepository ??= new FollowerRepository(context);

        private IDirectMessageRepository? directMessageRepository;
        public IDirectMessageRepository DirectMessageRepository => directMessageRepository ??= new DirectMessageRepository(context);

        private INotificationRepository? notificationRepository;
        public INotificationRepository NotificationRepository => notificationRepository ??= new NotificationRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                await DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
