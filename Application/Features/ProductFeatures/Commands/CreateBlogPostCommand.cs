using Domain.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateBlogPostCommand : IRequest<CreateBlogPostModelDto>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public List<BlogPostTag> BlogPostTags { get; set; }
    }
}
