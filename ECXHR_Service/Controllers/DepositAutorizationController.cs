
using ECX.HR.Application.CQRS.DepositAutorization.Request.Command;
using ECX.HR.Application.CQRS.DepositAutorization.Request.Queries;

using ECX.HR.Application.DTOs.DepositAutorizations;

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
    public class DepositAutorizationController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DepositAutorizationController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<DepositAutorizationController>
        [HttpGet]
        public async Task<ActionResult<List<DepositAutorizationDto>>> Get()
        {
            var DepositAutorization = await _mediator.Send(new GetDepositAutorizationListRequest());
            return Ok(DepositAutorization);
        }

        // GET api/<DepositAutorizationController>/5
        [HttpGet("{empid}")]
        public async Task<ActionResult<DepositAutorizationDto>> Get(Guid empid)
        {
            var DepositAutorization = await _mediator.Send(new GetDepositAutorizationDetailRequest { EmpId = empid });
            return Ok(DepositAutorization);
        }

        // POST api/<DepositAutorizationController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] DepositAutorizationDto DepositAutorization)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateDepositAutorizationCommand { DepositAutorizationDto = DepositAutorization };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DepositAutorizationController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] DepositAutorizationDto DepositAutorization)
        {
            var command = new UpdateDepositAutorizationCommand { DepositAutorizationDto = DepositAutorization };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDepositAutorizationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}