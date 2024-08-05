
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECX.HR.Application.CQRS.PayRoll.Request.Command;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Application.CQRS.PayRoll.Request.Queries;
using ECX.HR.Application.CQRS.TempPayroll.Request.Queries;
using ECX.HR.Application.DTOs.TempPayroll;
using ECX.HR.Application.CQRS.TempPayroll.Request.Command;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempPayRollController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public TempPayRollController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<PayrollController>
        [HttpGet]
        public async Task<ActionResult<List<TempPayRollDto>>> Get()
        {
            var Payroll = await _mediator.Send(new GetTempPayrollListRequest());
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
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] TempPayRollDto Payroll)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateTempPayrollCommand { TempPayRollDto = Payroll };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PayrollController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] TempPayRollDto Payroll)
        {
            var command = new UpdateTempPayrollCommand { TempPayRollDto = Payroll };
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

