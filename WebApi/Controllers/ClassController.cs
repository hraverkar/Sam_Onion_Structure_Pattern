using Application.Features.ProductFeatures.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all classes details.
        /// </summary>
        /// <param></param>
        /// <returns>Get all classes</returns>
        [HttpGet("get-all-class")]
        public async Task<IActionResult> GetAllClassAsync()
        {
            try
            {
                var query = new GetAllClassQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
