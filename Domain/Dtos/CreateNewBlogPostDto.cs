using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class CreateNewBlogPostDto
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public List<BlogPostTag> BlogPostTags { get; set; }
    }
}
