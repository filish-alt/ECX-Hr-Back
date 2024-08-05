using ECX.HR.Application.CQRS.OverTime.Request.Command;
using ECX.HR.Application.CQRS.OverTime.Request.Queries;
using ECX.HR.Application.DTOs.OverTime;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverTimeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public OverTimeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<OverTimeController>
        [HttpGet]
        public async Task<ActionResult<List<OverTimeDto>>> Get()
        {
            var OverTime = await _mediator.Send(new GetListOverTimeRequest());
            return Ok(OverTime);
        }

      [HttpGet("{Empid}")]
               public async Task<ActionResult<OverTimeDto>> GetByEmpId(Guid Empid)
               {
                   var OverTime = await _mediator.Send(new GetDetailOverTimeRequest { Empid = Empid });
                   return Ok(OverTime);
               }
        // POST api/<OverTimeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] OverTimeDto OverTime)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateOverTimeCommand { OverTimeDto = OverTime };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OverTimeController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] OverTimeDto OverTime)
        {
            var command = new UpdateOverTimeCommand { OverTimeDto = OverTime };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteOverTimeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

