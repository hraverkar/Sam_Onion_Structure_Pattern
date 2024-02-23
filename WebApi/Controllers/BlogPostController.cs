using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("add-blogpost")]
        //public async Task<IActionResult> AddNewBlog([FromBody] CreateNewBlogPostDto request)
        //{
        //    try
        //    {


        //    } catch(Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
