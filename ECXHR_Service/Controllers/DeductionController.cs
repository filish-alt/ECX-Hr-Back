using ECX.HR.Application.CQRS.Deduction.Request.Command;
using ECX.HR.Application.CQRS.Deduction.Request.Queries;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public DeductionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<DeductionController>
        [HttpGet]
        public async Task<ActionResult<List<DeductionDto>>> Get()
        {
            var Deduction = await _mediator.Send(new GetDeductionListRequest());
            return Ok(Deduction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeductionDto>> GetByEmpId(Guid id)
        {
            var Deduction = await _mediator.Send(new GetDeductionDetailRequest { Id = id });
            return Ok(Deduction);
        }
        // POST api/<DeductionController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] DeductionDto Deduction)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateDeductionCommand { deductionDto = Deduction };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DeductionController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] DeductionDto Deduction)
        {
            var command = new UpdateDeductionCommand { deductionDto = Deduction };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDeductionCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("id/{fileId}")]
        public async Task<IActionResult> GetFile(Guid fileId)
        {


            var fileData = await _mediator.Send(new GetFileDeductionCommand(fileId));

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

