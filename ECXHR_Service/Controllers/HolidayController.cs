

using ECX.HR.Application.CQRS.Holiday.Request.Command;
using ECX.HR.Application.CQRS.Holiday.Request.Queries;
using ECX.HR.Application.DTOs.Holiday;
using ECX.HR.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HolidayController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<HolidayController>
        [HttpGet]
        public async Task<ActionResult<List<HolidayDto>>> Get()
        {
            var Holiday = await _mediator.Send(new GetHolidayListRequest());
            return Ok(Holiday);
        }

        // GET api/<HolidayController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayDto>> Get(Guid id)
        {
            var Holiday = await _mediator.Send(new GetHolidayDetailRequest { Id = id });
            return Ok(Holiday);
        }

        // POST api/<HolidayController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] HolidayDto Holiday)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateHolidayCommand { HolidayDto = Holiday };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<HolidayController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] HolidayDto Holiday)
        {
            var command = new UpdateHolidayCommand { HolidayDto = Holiday };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteHolidayCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}