using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tag : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BlogPostTag> BlogPostTags { get; set; }
    }
}
