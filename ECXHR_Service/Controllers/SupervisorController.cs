
using ECX.HR.Application.CQRS.Supervisor.Request.Command;
using ECX.HR.Application.CQRS.Supervisor.Request.Queries;

using ECX.HR.Application.DTOs.Supervisors;

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
    public class SupervisorController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SupervisorController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<SupervisorController>
        [HttpGet]
        public async Task<ActionResult<List<SupervisorDto>>> Get()
        {
            var Supervisor = await _mediator.Send(new GetSupervisorListRequest());
            return Ok(Supervisor);
        }

        // GET api/<SupervisorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupervisorDto>> Get(Guid id)
        {
            var Supervisor = await _mediator.Send(new GetSupervisorDetailRequest { Id = id });
            return Ok(Supervisor);
        }

        // POST api/<SupervisorController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] SupervisorDto Supervisor)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateSupervisorCommand { SupervisorDto = Supervisor };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<SupervisorController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] SupervisorDto Supervisor)
        {
            var command = new UpdateSupervisorCommand { SupervisorDto = Supervisor };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteSupervisorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}