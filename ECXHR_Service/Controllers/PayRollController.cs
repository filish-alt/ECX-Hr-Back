

using ECX.HR.Application.CQRS.PayRoll.Request.Command;
using ECX.HR.Application.CQRS.PayRoll.Request.Queries;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;




namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayRollController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PayRollController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<PayrollController>
        [HttpGet]
        public async Task<ActionResult<List<PayRollDto>>> Get()
        {
            var Payroll = await _mediator.Send(new GetPayrollListRequest());
            return Ok(Payroll);
        }

        /*       [HttpGet("{Empid}")]
               public async Task<ActionResult<EmployeeDto>> GetByEmpId(Guid Empid)
               {
                   var Payroll = await _mediator.Send(new GetPayrollDetailRequest { EmpId = Empid });
                   return Ok(Payroll);
               }*/
        // POST api/<PayrollController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] PayRollDto Payroll)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreatePayrollCommand { PayRollDto = Payroll };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PayrollController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] PayRollDto Payroll)
        {
            var command = new UpdatePayrollCommand { PayRollDto = Payroll };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePayrollCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

