



using ECX.HR.Application.CQRS.ContractEmployee.Request.Command;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Queries;

using ECX.HR.Application.DTOs.PayrollContract;
using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractEmployeeController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ContractEmployeeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<ContractEmployeeController>
        [HttpGet]
        public async Task<ActionResult<List<ContractRegistrationDto>>> Get()
        {
            var ContractEmployee = await _mediator.Send(new GetContractEmployeeList());
            return Ok(ContractEmployee);
        }

        /*       [HttpGet("{Empid}")]
               public async Task<ActionResult<EmployeeDto>> GetByEmpId(Guid Empid)
               {
                   var ContractEmployee = await _mediator.Send(new GetContractEmployeeDetailRequest { EmpId = Empid });
                   return Ok(ContractEmployee);
               }*/
        // POST api/<ContractEmployeeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] ContractRegistrationDto ContractEmployee)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateContractEmployeeCommand { ContractEmployeeDto = ContractEmployee };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ContractEmployeeController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] ContractRegistrationDto ContractEmployee)
        {
            var command = new UpdateContractEmployee { ContractEmpDto = ContractEmployee };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteContractEmployeeCommand { EmpId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}