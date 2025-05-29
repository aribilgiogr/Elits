using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Bases
{
    public abstract class PostBaseDto
    {
        public required string Content { get; set; }
        public string? AttachedImageUrl { get; set; }
    }
}
