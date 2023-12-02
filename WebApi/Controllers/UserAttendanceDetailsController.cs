using Application.Features.ProductFeatures.Commands;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
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

        /// <summary>
        /// Upload Files
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Upload Files</returns>
        [HttpPost("upload-file"), FormatFilter]
        public async Task<IActionResult> UploadFile([FromBody] FileDto request)
        {
            try
            {
                var command = new CreateFileCommand(request.FileName, request.FileData, null);
                var result = await _mediator.Send(command);
                return Ok(new { Value = result });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete File.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted file result</returns>
        [HttpDelete("{id}"), FormatFilter]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new DeleteFileCommand(id);
                var result = await _mediator.Send(command);
                return Ok(new { Value = result });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
