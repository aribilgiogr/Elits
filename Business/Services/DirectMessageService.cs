using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.DirectMessage;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class DirectMessageService : IDirectMessageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DirectMessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeleteMessageAsync(Guid messageId)
        {
            await unitOfWork.DirectMessageRepository.DeleteOneAsync(messageId);
        }

        public async Task<IEnumerable<DirectMessageDTO>> GetConversationAsync(Guid userId1, Guid userId2)
        {
            var messages = await unitOfWork.DirectMessageRepository.FindManyAsync(
                x => (x.SenderId == userId1 && x.ReceiverId == userId2) || (x.SenderId == userId2 && x.ReceiverId == userId1),
                "Sender", "Receiver");
            return mapper.Map<IEnumerable<DirectMessageDTO>>(messages);
        }

        public async Task<IEnumerable<DirectMessageDTO>> GetMessagesAsync(Guid receiverId)
        {
            var messages = await unitOfWork.DirectMessageRepository.FindManyAsync(x => x.ReceiverId == receiverId, "Sender", "Receiver");
            return mapper.Map<IEnumerable<DirectMessageDTO>>(messages);
        }

        public async Task MarkAsReadAsync(Guid messageId)
        {
            var message = await unitOfWork.DirectMessageRepository.FindOneByKeyAsync(messageId);
            if (message != null)
            {
                message.IsRead = true;
                await unitOfWork.DirectMessageRepository.UpdateOneAsync(message);
                await unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception("Message not found");
            }
        }

        public async Task SendMessageAsync(CreateDirectMessageDTO create)
        {
            await unitOfWork.DirectMessageRepository.CreateOneAsync(mapper.Map<DirectMessage>(create));
        }
    }
}
