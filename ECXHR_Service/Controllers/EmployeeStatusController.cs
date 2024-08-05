
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Command;
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Queries;
using ECX.HR.Application.DTOs.EmployeeStatus;
using ECX.HR.Application.DTOs.EmployeeStatuss;

using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeStatusController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<EmployeeStatusController>
        [HttpGet]
        public async Task<ActionResult<List<EmployeeStatusDto>>> Get()
        {
            var EmployeeStatus = await _mediator.Send(new GetEmployeeStatusListRequest());
            return Ok(EmployeeStatus);
        }

        // GET api/<EmployeeStatusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeStatusDto>> Get(Guid id)
        {
            var EmployeeStatus = await _mediator.Send(new GetEmployeeStatusDetailRequest { Id = id });
            return Ok(EmployeeStatus);
        }

        // POST api/<EmployeeStatusController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] EmployeeStatusDto EmployeeStatus)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateEmployeeStatusCommand { EmployeeStatusDto = EmployeeStatus };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<EmployeeStatusController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] EmployeeStatusDto EmployeeStatus)
        {
            var command = new UpdateEmployeeStatusCommand { EmployeeStatusDto = EmployeeStatus };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEmployeeStatusCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}