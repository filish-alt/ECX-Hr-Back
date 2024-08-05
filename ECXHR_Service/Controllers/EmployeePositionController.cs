

using ECX.HR.Application.CQRS.EmployeePosition.Request.Command;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Queries;
using ECX.HR.Application.DTOs.EmployeePositions;

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
    public class EmployeePositionController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeePositionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<EmployeePositionController>
        [HttpGet]
        public async Task<ActionResult<List<EmployeePositionDto>>> Get()
        {
            var EmployeePosition = await _mediator.Send(new GetEmployeePositionListRequest());
            return Ok(EmployeePosition);
        }

        // GET api/<EmployeePositionController>/5
        [HttpGet("{Empid}")]
        public async Task<ActionResult<EmployeePositionDto>> Get(Guid Empid)
        {
            var EmployeePosition = await _mediator.Send(new GetEmployeePositionDetailRequest { EmpId = Empid });
            return Ok(EmployeePosition);
        }

        // POST api/<EmployeePositionController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] EmployeePositionDto EmployeePosition)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateEmployeePositionCommand { EmployeePositionDto = EmployeePosition };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<EmployeePositionController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] EmployeePositionDto EmployeePosition)
        {
            var command = new UpdateEmployeePositionCommand { EmployeePositionDto = EmployeePosition };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEmployeePositionCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}