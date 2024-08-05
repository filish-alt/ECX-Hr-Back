

using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.WorkExperience.Request.Command;
using ECX.HR.Application.CQRS.WorkExperience.Request.Queries;
using ECX.HR.Application.DTOs.WorkExperiences;
using ECX.HR.Application.Response;
using ECX.HR.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperience﻿﻿Controller : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
       

        public WorkExperience﻿﻿Controller(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            
        }
        // GET: api/<WorkExperience﻿﻿Controller>
        [HttpGet]
        public async Task<ActionResult<List<WorkExperience﻿﻿Dto>>> Get()
        {
            var WorkExperience﻿﻿ = await _mediator.Send(new GetWorkExperience﻿﻿ListRequest());
            return Ok(WorkExperience﻿﻿);
        }

        // GET api/<WorkExperience﻿﻿Controller>/5
       
        // POST api/<WorkExperience﻿﻿Controller>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] WorkExperience﻿﻿Dto WorkExperience﻿﻿)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateWorkExperience﻿﻿Command { WorkExperience﻿﻿Dto = WorkExperience﻿﻿ };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<WorkExperience﻿﻿Controller>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] WorkExperience﻿﻿Dto WorkExperience﻿﻿)
        {
            var command = new UpdateWorkExperience﻿﻿Command { WorkExperience﻿﻿Dto = WorkExperience﻿﻿ };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(Guid fileId)
        {


            var fileData = await _mediator.Send(new GetWorkExperienceFileCommand(fileId));

            if (fileData == null)
            {
                return NotFound(); // File not found
            }

            // Determine the file's content type (e.g., application/pdf, image/jpeg, etc.)
            string contentType = "application/pdf"; // Set a default content type
            Response.Headers.Add("contentType", "application/pdf");
            // You can set the content type based on the file's type or extension
            // Example: if (fileExtension == ".pdf") contentType = "application/pdf";

            // Return the file as a downloadable attachment
            return File(fileData, contentType);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteWorkExperience﻿﻿Command { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}