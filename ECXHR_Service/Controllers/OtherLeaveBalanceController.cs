
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Queries;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class otherLeaveBalanceController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public otherLeaveBalanceController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<OtherLeaveBalanceDto>>> Get()
        {
            var otherLeaveBalance = await _mediator.Send(new GetOtherLeaveBalanceListRequest());
            return Ok(otherLeaveBalance);
        }

        [HttpGet("{Empid}")]
        public async Task<ActionResult<OtherLeaveBalanceDto>> GetByEmpId(Guid Empid)
        {
            var address = await _mediator.Send(new GetOtherLeaveBalanceDetailRequest { EmpId = Empid });
            return Ok(address);
        }
        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] OtherLeaveBalanceDto otherLeaveBalance)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateOtherLeaveBalanceCommand {OtherLeaveBalanceDto =otherLeaveBalance };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] OtherLeaveBalanceDto otherLeaveBalance)
        {
            var command = new UpdateOtherLeaveBalanceCommand {OtherLeaveBalanceDto =otherLeaveBalance };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteOtherLeaveBalanceCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}