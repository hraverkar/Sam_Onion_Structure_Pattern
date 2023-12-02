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

        // GET: api/<ClassControllerz>
        [HttpGet("getAll-class")]
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

        // GET api/<ClassControllerz>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClassControllerz>
        [HttpPost("add-class")]
        public void Post([FromBody] ClassTable request)
        {
           
        }

        // PUT api/<ClassControllerz>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClassControllerz>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
