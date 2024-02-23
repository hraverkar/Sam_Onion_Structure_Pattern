using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class CreateBlogPostModelDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
        public string AuthorId { get; set; }
        public List<BlogPostTag> BlogPostTags { get; set; }

    }
}
