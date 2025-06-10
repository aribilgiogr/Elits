using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.Notification
{
    public class NotificationDTO
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public string Type { get; set; } = null!;
        public Guid? RelatedPostId { get; set; }
        public Guid? RelatedCommentId { get; set; }
    }
}
