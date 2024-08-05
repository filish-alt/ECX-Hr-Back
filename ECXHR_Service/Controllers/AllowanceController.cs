
using ECX.HR.Application.CQRS.Allowance.Request.Command;
using ECX.HR.Application.CQRS.Allowance.Request.Queries;
using ECX.HR.Application.CQRS.Allowances.Request.Command;
using ECX.HR.Application.DTOs.Allowances.cs;
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
    public class AllowanceController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AllowanceController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AllowanceController>
        [HttpGet]
        public async Task<ActionResult<List<AllowanceDto>>> Get()
        {
            var Allowance = await _mediator.Send(new GetAllowanceListRequest());
            return Ok(Allowance);
        }

        // GET api/<AllowanceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowanceDto>> Get(Guid id)
        {
            var Allowance = await _mediator.Send(new GetAllowanceDetailRequest { Id = id });
            return Ok(Allowance);
        }

        // POST api/<AllowanceController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AllowanceDto Allowance)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateAllowanceCommand { AllowanceDto = Allowance };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AllowanceController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] AllowanceDto Allowance)
        {
            var command = new UpdateAllowanceCommand { AllowanceDto = Allowance };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAllowanceCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}