
using ECX.HR.Application.CQRS.Division.Request.Command;
using ECX.HR.Application.CQRS.Division.Request.Queries;
using ECX.HR.Application.DTOs.Division;

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
    public class DivisionController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DivisionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<DivisionController>
        [HttpGet]
        public async Task<ActionResult<List<DivisionDto>>> Get()
        {
            var Division = await _mediator.Send(new GetDivisionListRequest());
            return Ok(Division);
        }

        // GET api/<DivisionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DivisionDto>> Get(Guid id)
        {
            var Division = await _mediator.Send(new GetDivisionDetailRequest { DivisionId = id });
            return Ok(Division);
        }

        // POST api/<DivisionController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] DivisionDto Division)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateDivisionCommand { DivisionDto = Division };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DivisionController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] DivisionDto Division)
        {
            var command = new UpdateDivisionCommand { DivisionDto = Division };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDivisionCommand { divisionId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}