
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.CQRS.Tax.Request.Command;
using ECX.HR.Application.CQRS.Tax.Request.Queries;
using ECX.HR.Application.DTOs.Tax;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public TaxController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<TaxController>
        [HttpGet]
        public async Task<ActionResult<List<TaxDto>>> Get()
        {
            var Tax = await _mediator.Send(new GetTaxListRequest());
            return Ok(Tax);
        }

        [HttpGet("{Empid}")]
        public async Task<ActionResult<TaxDto>> GetByEmpId(Guid id)
        {
            var Tax = await _mediator.Send(new GetTaxDetailRequest { Id = id });
            return Ok(Tax);
        }
        // POST api/<TaxController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] TaxDto Tax)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateTaxCommand { TaxDto = Tax };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<TaxController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] TaxDto Tax)
        {
            var command = new UpdateTaxCommand { TaxDto = Tax };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTaxCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

