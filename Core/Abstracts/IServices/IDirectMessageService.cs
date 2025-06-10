using Core.Concretes.DTOs.DirectMessage;

namespace Core.Abstracts.IServices
{
    public interface IDirectMessageService
    {
        Task SendMessageAsync(CreateDirectMessageDTO create);
        Task<IEnumerable<DirectMessageDTO>> GetConversationAsync(Guid userId1, Guid userId2);
        Task<IEnumerable<DirectMessageDTO>> GetMessagesAsync(Guid receiverId);
        Task MarkAsReadAsync(Guid messageId);
        Task DeleteMessageAsync(Guid messageId);
    }
}
