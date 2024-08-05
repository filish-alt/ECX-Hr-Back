
using ECX.HR.Application.CQRS.Step.Request.Command;
using ECX.HR.Application.CQRS.Step.Request.Queries;
using ECX.HR.Application.DTOs.Step;

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
    public class StepController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StepController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<StepController>
        [HttpGet]
        public async Task<ActionResult<List<StepDto>>> Get()
        {
            var Step = await _mediator.Send(new GetStepListRequest());
            return Ok(Step);
        }

        // GET api/<StepController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StepDto>> Get(Guid id)
        {
            var Step = await _mediator.Send(new GetStepDetailRequest { Id = id });
            return Ok(Step);
        }

        // POST api/<StepController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] StepDto Step)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateStepCommand { StepDto = Step };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<StepController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] StepDto Step)
        {
            var command = new UpdateStepCommand { StepDto = Step };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteStepCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}