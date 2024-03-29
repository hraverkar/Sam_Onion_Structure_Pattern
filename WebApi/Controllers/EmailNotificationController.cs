﻿using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Application.Interfaces;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // POST: api/EmailNotifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("sendEmail")]
        public async Task<IActionResult> PostEmailNotification([FromBody] EmailNotificationDto emailNotification)
        {
            if (emailNotification == null)
            {
                return Problem("Email Notification is null.");
            }

            var command = new EmailNotificationCommand(emailNotification);
            var result = await _mediator.Send(command);
            return Ok(new { Value = result });

        }

        [HttpPost("bulk-sendEmail")]
        public async Task<IActionResult> PostBulkEmailNotification([FromBody] FileDto file)
        {
            if (file == null)
            {
                return Problem("Email Notification is null.");
            }
            var command = new SendBulkEmailNotificationCommand(file.FileName, file.FileData, null);
            var result = await _mediator.Send(command);
            return Ok(new { Value = result });

        }

        [HttpGet("donwload-bulk-email-template")]
        public async Task<IActionResult> DownloadEmailTemplate(string FileName)
        {
            var query = new GetTemplateQuery(FileName);
            var result = await _mediator.Send(query);
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileResult = new FileContentResult(result, contentType)
            {
                FileDownloadName = FileName
            };
            return Ok(fileResult);
        }
    }
}
