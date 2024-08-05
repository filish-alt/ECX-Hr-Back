
using ECX.HR.Application.CQRS.Allowance.Request.Command;
using ECX.HR.Application.CQRS.Allowance.Request.Queries;
using ECX.HR.Application.CQRS.Allowances.Request.Command;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Queries;
using ECX.HR.Application.CQRS.MedicalFund.Request.Command;
using ECX.HR.Application.CQRS.MedicalFund.Request.Queries;
using ECX.HR.Application.DTOs.ActingAssigment;
using ECX.HR.Application.DTOs.MedicalBalance;
using ECX.HR.Application.DTOs.MedicalFunds;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalFundController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MedicalFundController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
  
        [HttpGet]
        public async Task<ActionResult<List<MedicalFundDto>>> Get()
        {
            var med = await _mediator.Send(new GetMedicalFundListRequest());
            return Ok(med);
        }


        [HttpGet("empid/{Empid}")]
        public async Task<ActionResult<MedicalFundDto>> Get(Guid empid)
        {
            var Acting = await _mediator.Send(new GetMedicalFundDetailRequest { Id = empid });
            return Ok(Acting);
        }
        [HttpGet("status/{Status}")]
        public async Task<ActionResult<MedicalFundDto>> GetStatus(string status)
        {
            var Acting = await _mediator.Send(new GetMedicalFundStatusDetailRequest { approvalStatus = status });
            return Ok(Acting);
        }

        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] MedicalFundDto MedicalFundDto)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateMedicalFundCommand { MedicalFundDto = MedicalFundDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AllowanceController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] MedicalFundDto MedicalFundDto)
        {
            var command = new UpdateMedicalFund { MedicalFundDto = MedicalFundDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMedicalFund { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(Guid fileId)
        {


            var fileData = await _mediator.Send(new GetFileByIdCommand(fileId));

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
        [HttpGet("Receipt/{fileId}")]
        public async Task<IActionResult> GetReceiptFile(Guid fileId)
        {


            var fileData = await _mediator.Send(new GetReceiptFileByIdCommand(fileId));

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