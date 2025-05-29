using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.PostLike
{
    public class PostLikeDto
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Guid PostId { get; set; }
    }
}
