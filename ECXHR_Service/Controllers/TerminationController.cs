

using ECX.HR.Application.CQRS.Termination.Request.Command;
using ECX.HR.Application.CQRS.Termination.Request.Queries;
using ECX.HR.Application.DTOs.Termination;
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
    public class TerminationController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TerminationController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<TerminationController>
        [HttpGet]
        public async Task<ActionResult<List<TerminationDto>>> Get()
        {
            var Termination = await _mediator.Send(new GetTerminationListRequest());
            return Ok(Termination);
        }

        // GET api/<TerminationController>/5
        [HttpGet("{Empid}")]
        public async Task<ActionResult<TerminationDto>> Get(Guid Empid)
        {
            var Termination = await _mediator.Send(new GetTerminationDetailRequest { EmpId = Empid });
            return Ok(Termination);
        }

        // POST api/<TerminationController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] TerminationDto Termination)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateTerminationCommand { TerminationDto = Termination };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<TerminationController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] TerminationDto Termination)
        {
            var command = new UpdateTerminationCommand { TerminationDto = Termination };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTerminationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}