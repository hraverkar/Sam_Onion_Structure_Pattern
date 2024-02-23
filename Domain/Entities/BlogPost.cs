using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public List<BlogPostTag> BlogPostTags { get; set; }
    }
}
