using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-author")]
        public async Task<IActionResult> GetAllAuthor()
        {
            try
            {
                var command = new GetAllAuthorQuery();
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("add-author")]
        public async Task<IActionResult> AddAuthor([FromBody] AddNewAuthorDto request)
        {
            try
            {
                var command = new CreateAuthorCommand(request.Name, request.Email, request.Description);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete-author")]
        public async Task<IActionResult> DeleteAuthor(Guid Id)
        {
            try
            {
                var query = new DeleteAuthorQuery(Id);
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
