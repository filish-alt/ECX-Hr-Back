

using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Queries;
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
    public class LeaveTypeController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LeaveTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var LeaveType = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(LeaveType);
        }

        /*       [HttpGet("{Empid}")]
               public async Task<ActionResult<EmployeeDto>> GetByEmpId(Guid Empid)
               {
                   var address = await _mediator.Send(new GetAddressDetailRequest { EmpId = Empid });
                   return Ok(address);
               }*/
        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] LeaveTypeDto LeaveType)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateLeaveTypeCommand { LeaveTypeDto = LeaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] LeaveTypeDto LeaveType)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDto = LeaveType };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveTypeCommand { leaveTypeId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}