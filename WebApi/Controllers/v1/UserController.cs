using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            var command = new CreateUserCommand(request.Id, request.Name, request.Email, request.CreatedAt, request.CreatedBy);
            await Mediator.Send(command);
            return Ok();
        }
        
        /// <summary>
        /// Get All Users .
        /// </summary>
        /// <param></param>
        /// <returns>Get All Users</returns>
        [HttpGet]
        [Route("/get-all-user")]
        public async Task<ActionResult<IList<User>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}