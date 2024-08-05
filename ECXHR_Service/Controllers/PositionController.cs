
using ECX.HR.Application.CQRS.Position.Request.Command;
using ECX.HR.Application.CQRS.Position.Request.Queries;
using ECX.HR.Application.DTOs.Positions;

using ECX.HR.Application.Response;
//using HRMsystem.Application.Features.Address.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PositionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<PositionController>
        [HttpGet]
        public async Task<ActionResult<List<PositionDto>>> Get()
        {
            var Position = await _mediator.Send(new GetPositionListRequest());
            return Ok(Position);
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDto>> Get(Guid id)
        {
            var Position = await _mediator.Send(new GetPositionDetailRequest { PositionId = id });
            return Ok(Position);
        }

        // POST api/<PositionController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] PositionDto Position)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreatePositionCommand { PositionDto = Position };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] PositionDto Position)
        {
            var command = new UpdatePositionCommand { PositionDto = Position };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePositionCommand { PositionId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}