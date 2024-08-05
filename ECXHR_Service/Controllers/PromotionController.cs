

using ECX.HR.Application.CQRS.Level.Request.Queries;
using ECX.HR.Application.CQRS.Promotion.Request.Command;
using ECX.HR.Application.CQRS.Promotion.Request.Queries;

using ECX.HR.Application.DTOs.Promotion;
using ECX.HR.Application.DTOs.Promotions;
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
    public class PromotionController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PromotionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<PromotionController>
        [HttpGet]
        public async Task<ActionResult<List<PromotionDto>>> Get()
        {
            var Promotion = await _mediator.Send(new GetPromotionListRequest());
            return Ok(Promotion);
        }

        // GET api/<PromotionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDto>> Get(Guid id)
        {
            var Promotion = await _mediator.Send(new GetPromotionDetailRequest { Id = id });
            return Ok(Promotion);
        }

        // POST api/<PromotionController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] PromotionDto Promotion)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreatePromotionCommand { PromotionDto = Promotion };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PromotionController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] PromotionDto Promotion)
        {
            var command = new UpdatePromotionCommand { PromotionDto = Promotion };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePromotionCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}