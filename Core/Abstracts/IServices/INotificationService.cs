using Core.Concretes.DTOs.Notification;
using Core.Concretes.Entities;

namespace Core.Abstracts.IServices
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(CreateNotificationDTO create);
        Task<IEnumerable<NotificationDTO>> GetUserNotificationsAsync(Guid userId);
        Task MarkAsReadAsync(Guid notificationId);
    }

}
