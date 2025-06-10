using Core.Abstracts.IRepositories;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICommentRepository CommentRepository { get; }
        IPostRepository PostRepository { get; }
        IPostLikeRepository PostLikeRepository { get; }
        IFollowerRepository FollowerRepository { get; }
        IDirectMessageRepository DirectMessageRepository { get; }
        INotificationRepository NotificationRepository { get; }
        Task CommitAsync();
    }
}
