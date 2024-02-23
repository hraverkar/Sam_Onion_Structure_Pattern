using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogPostTag : BaseEntity
    {
        public Guid BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
