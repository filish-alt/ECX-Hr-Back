
using ECX.HR.Application.CQRS.PayrollContract.Request;
using ECX.HR.Application.CQRS.PayrollContract.Request.Command;
using ECX.HR.Application.CQRS.PayrollContract.Request.Queries;
using ECX.HR.Application.DTOs.PayrollContract;
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
    public class PayrollContractController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PayrollContractController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<PayrollContracteController>
        [HttpGet]
        public async Task<ActionResult<List<PayrollContractDto>>> Get()
        {
            var PayrollContracte = await _mediator.Send(new GetContractListRequest());
            return Ok(PayrollContracte);
        }

        // GET api/<PayrollContracteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollContractDto>> Get(Guid id)
        {
            var PayrollContracte = await _mediator.Send(new GetContractDetailRequest { Id = id });
            return Ok(PayrollContracte);
        }

        // POST api/<PayrollContracteController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] PayrollContractDto PayrollContract)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateContractCommand { PayrollContractDto = PayrollContract };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PayrollContracteController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] PayrollContractDto PayrollContracte)
        {
            var command = new UpdateContractCommand { PayrollContractDto = PayrollContracte };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteContractCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}