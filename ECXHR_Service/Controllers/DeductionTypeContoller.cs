using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.CQRS.DductionType.Request.Queries;
using ECX.HR.Application.DTOs.DeductionType;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionType: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public DeductionType(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<DeductionTypeController>
        [HttpGet]
        public async Task<ActionResult<List<DeductionTypeDto>>> Get()
        {
            var DeductionType = await _mediator.Send(new GetDeductionTypeListRequest());
            return Ok(DeductionType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeductionTypeDto>> GetByEmpId(Guid id)
        {
            var DeductionType = await _mediator.Send(new GetDeductionTypeDetailRequest { Id = id });
            return Ok(DeductionType);
        }
        // POST api/<DeductionTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] DeductionTypeDto DeductionType)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateDeductionTypeCommand { deductionTypeDto = DeductionType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DeductionTypeController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] DeductionTypeDto DeductionType)
        {
            var command = new UpdateDeductionTypeCommand { DeductionTypeDto = DeductionType };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDeductionTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

