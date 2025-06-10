using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.DirectMessage
{
    public class CreateDirectMessageDTO
    {
        public required Guid SenderId { get; set; }
        public required Guid ReceiverId { get; set; }
        public required string Content { get; set; }
    }
}
