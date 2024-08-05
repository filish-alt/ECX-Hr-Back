using ECX.HR.Application.CQRS.AllowanceType.Request.Command;
using ECX.HR.Application.CQRS.AllowanceType.Request.Queries;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.DTOs.AllowanceType;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class AllowanceType : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AllowanceType(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AllowanceTypeController>
        [HttpGet]
        public async Task<ActionResult<List<AllowanceTypeDto>>> Get()
        {
            var AllowanceType = await _mediator.Send(new GetAllowanceTypeListRequest());
            return Ok(AllowanceType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AllowanceTypeDto>> GetByEmpId(Guid id)
        {
            var AllowanceType = await _mediator.Send(new GetAllowanceTypeDetailRequest { Id = id });
            return Ok(AllowanceType);
        }
        // POST api/<AllowanceTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AllowanceTypeDto AllowanceType)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateAllowanceTypeCommand { AllowanceTypeDto = AllowanceType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AllowanceTypeController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] AllowanceTypeDto AllowanceType)
        {
            var command = new UpdateAllowanceTypeCommand { AllowanceTypeDto = AllowanceType };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAllowanceTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
