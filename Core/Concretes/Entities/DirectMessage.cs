using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class DirectMessage
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;

        public required Guid SenderId { get; set; }
        public ApplicationUser? Sender { get; set; }

        public required Guid ReceiverId { get; set; }
        public ApplicationUser? Receiver { get; set; }

        public bool IsRead { get; set; } = false;
    }
}
