using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Queries;
using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Queries;
using ECX.HR.Application.CQRS.Outsource.Request.Command;
using ECX.HR.Application.CQRS.Outsource.Request.Queries;
using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.DTOs.Outsource;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class OutSourceController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public OutSourceController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<OutsourceDto>>> Get()
        {
            var outsource = await _mediator.Send(new GetOutsoueceListRequest());
            var outsourceWoFile = outsource.Select(l =>
            {
                l.File = null;
                return l;
            });
            return Ok(outsourceWoFile);

        }


            [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] OutsourceDto outsource)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateOutsourceCommand { OutsourceDto = outsource };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] OutsourceDto outsource)
        {
            var command = new UpdateOutsourceCommand { OutsourceDto = outsource };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteOutsourceCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }




        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(Guid fileId)
        {


            var fileData = await _mediator.Send(new GetFileOutsourceCommand(fileId));

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
    }
}