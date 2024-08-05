

using ECX.HR.Application.CQRS.Level.Request.Command;
using ECX.HR.Application.CQRS.Level.Request.Queries;
using ECX.HR.Application.DTOs.Levels;
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
    public class LevelController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LevelController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<LevelController>
        [HttpGet]
        public async Task<ActionResult<List<LevelDto>>> Get()
        {
            var Level = await _mediator.Send(new GetLevelListRequest());
            return Ok(Level);
        }

        // GET api/<LevelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelDto>> Get(Guid id)
        {
            var Level = await _mediator.Send(new GetLevelDetailRequest { LevelId = id });
            return Ok(Level);
        }

        // POST api/<LevelController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] LevelDto Level)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateLevelCommand { LevelDto = Level };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LevelController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] LevelDto Level)
        {
            var command = new UpdateLevelCommand { LevelDto = Level };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLevelCommand { LevelId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}