

using ECX.HR.Application.CQRS.Employee.Request.Queries;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Queries;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Queries;
using ECX.HR.Application.CQRS.LeaveRequest.Handler.Command;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Queries;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Queries;
using ECX.HR.Application.DTOs.Leave;

using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LeaveRequestController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var LeaveRequest = await _mediator.Send(new GetLeaveRequestListCommand());
            var LeaveRequestWoFile = LeaveRequest.Select(l =>
            {
                l.File = null;
                return l;
            });
            return Ok(LeaveRequestWoFile);
        }


        [HttpGet("empId/{Empid}")]
        public async Task<ActionResult<LeaveRequestDto>> GetByEmpId(Guid Empid)
        {
            var LeaveRequest = await _mediator.Send(new GetLeaveRequestByIdCommand { EmpId = Empid });
            var LeaveRequestWoFile = LeaveRequest.Select(l =>
            {
                l.File = null;
                return l;
            });
            return Ok(LeaveRequestWoFile);
        }
        [HttpGet("status/{LeaveStatus}/{Supervisor}")]
        public async Task<ActionResult<LeaveRequestDto>> GetByStatus(string LeaveStatus, string Supervisor)
        {
            var LeaveRequest = await _mediator.Send(new GetLeaveRequestStatusByIdCommand { LeaveStatus = LeaveStatus , Supervisor = Supervisor }) ;
     
            return Ok(LeaveRequest);
        }
        [HttpGet("status/{LeaveStatus}")]
        public async Task<ActionResult<LeaveRequestDto>> GetAllByStatus(string LeaveStatus)
        {
            var LeaveRequest = await _mediator.Send(new GetLeaveRequestAllStatusCommand { LeaveStatus = LeaveStatus });
            var LeaveRequestWoFile = LeaveRequest.Select(l =>
            {
                l.File = null;
                return l;
            });
            return Ok(LeaveRequestWoFile);
        }
        // 
        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] LeaveRequestDto leaveRequestDto)
        {
            var user = _httpContextAccessor.HttpContext.User;


            var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequestDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        // PUT api/<AddressController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] LeaveRequestDto LeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { LeaveRequestDto = LeaveRequest };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }
        // PUT: api/LeaveRequest/UpdateStatus/5
        // PUT api/<AddressController>/5
      


        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(Guid fileId)
        {


            var fileData = await _mediator.Send(new GetFileRequestCommand(fileId));

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
        [HttpGet("GetLeaveData/{id}")]
        public async Task<ActionResult<CombinedLeaveDataDto>> GetLeaveData(Guid id)
        {
            try
            {
                // Fetch data from different tables
                var employee = await _mediator.Send(new GetEmployeeDetailRequest { EmpId = id });
               
                var leaveRequest = await _mediator.Send(new GetLeaveRequestByIdCommand { EmpId = id });
                var annualLeaveBalance = await _mediator.Send(new GetLeaveBalanceDetailRequest { EmpId = id });
                var otherLeaveBalance = await _mediator.Send(new GetOtherLeaveBalanceDetailRequest { EmpId = id });
              
                // Create a CombinedEmployeeDataDto and populate it
                var combinedData = new CombinedLeaveDataDto
                {
                    Employee = employee,
                    LeaveRequests=leaveRequest,
                    AnnualLeaveBalances=annualLeaveBalance,
                    OtherLeaveBalances=otherLeaveBalance
                    // Add other data properties as needed
                };

                if (combinedData.Employee == null)
                {
                    return NotFound(); // Employee not found
                }

                return Ok(combinedData);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveRequestCommand { leaveRequestId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}