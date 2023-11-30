using Application.Features.ProductFeatures.Commands;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAttendanceDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAttendanceDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<UserAttendanceDetails>
        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile([FromBody] FileDto request)
        {
            try
            {
                var command = new CreateFileCommand(request.FileName, request.FileData, null);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<UserAttendanceDetails>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
