using ECX.HR.Application.CQRS.Bank.Request.Command;
using ECX.HR.Application.CQRS.Bank.Request.Queries;
using ECX.HR.Application.DTOs.Bank;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public BankController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<BankController>
        [HttpGet]
        public async Task<ActionResult<List<BankDto>>> Get()
        {
            var Bank = await _mediator.Send(new GetBankListRequest());
            return Ok(Bank);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankDto>> GetByEmpId(Guid id)
        {
            var Bank = await _mediator.Send(new GetBankDetailRequest { Id = id });
            return Ok(Bank);
        }
        // POST api/<BankController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] BankDto Bank)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateBankCommand { BankDto = Bank };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] BankDto Bank)
        {
            var command = new UpdateBankCommand { BankDto = Bank };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteBankCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

