using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Notification;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateNotificationAsync(CreateNotificationDTO create)
        {
            await unitOfWork.NotificationRepository.CreateOneAsync(mapper.Map<Notification>(create));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<NotificationDTO>> GetUserNotificationsAsync(Guid memberId)
        {
            var notifications = await unitOfWork.NotificationRepository.FindManyAsync(x => x.MemberId == memberId);
            return mapper.Map<IEnumerable<NotificationDTO>>(notifications);
        }

        public async Task MarkAsReadAsync(Guid notificationId)
        {
            var notification = await unitOfWork.NotificationRepository.FindOneByKeyAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await unitOfWork.NotificationRepository.UpdateOneAsync(notification);
                await unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception("Notification not found");
            }
        }
    }
}
