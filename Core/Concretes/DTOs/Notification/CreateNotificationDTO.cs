using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.Notification
{
    public class CreateNotificationDTO
    {
        public required Guid MemberId { get; set; }
        public required string Message { get; set; }
        public required string Type { get; set; }
        public Guid? RelatedPostId { get; set; }
        public Guid? RelatedCommentId { get; set; }
    }
}
