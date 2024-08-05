
using ECX.HR.Application.CQRS.Allowance.Request.Command;
using ECX.HR.Application.CQRS.Allowance.Request.Queries;
using ECX.HR.Application.CQRS.Allowances.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Queries;

using ECX.HR.Application.DTOs.MedicalBalance;

using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalBalanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MedicalBalanceController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicalBalanceDto>>> Get()
        {
            var med = await _mediator.Send(new GetMedicalBalanceListRequest());
            return Ok(med);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicalBalanceDto>>> Get(Guid id)
        {
            var med = await _mediator.Send(new GetMedicalBalanceDetailRequest { Id = id });
            return Ok(med);
        }


        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] MedicalBalanceDto MedicalBalanceDto)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateMedicalBalanceCommand { MedicalBalanceDto = MedicalBalanceDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AllowanceController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] MedicalBalanceDto MedicalBalanceDto)
        {
            var command = new UpdateMedicalBalance { MedicalBalanceDto = MedicalBalanceDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMedicalBalance { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}