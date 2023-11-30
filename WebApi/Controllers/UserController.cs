using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /// User Controller for all user activity
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            var command = new CreateUserCommand(request.Name, request.Email);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <param></param>
        /// <returns>Get All Users</returns>
        [HttpGet]
        [Route("get-all-user")]

        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete User</returns>
        [HttpDelete]
        [Route("delete-user")]
        public async Task<IActionResult> DeleteUsers([FromQuery] Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}