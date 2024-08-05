
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Command;
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Queries;
using ECX.HR.Application.DTOs.PromotionVacancy;


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
    public class PromotionVacancyController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PromotionVacancyController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<PromotionVacancyController>
        [HttpGet]
        public async Task<ActionResult<List<PromotionVacancyDto>>> Get()
        {
            var PromotionVacancy = await _mediator.Send(new GetPromotionVacancyListRequest());
            return Ok(PromotionVacancy);
        }

        // GET api/<PromotionVacancyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionVacancyDto>> Get(Guid id)
        {
            var PromotionVacancy = await _mediator.Send(new GetPromotionVacancyDetailRequest { VacancyId = id });
            return Ok(PromotionVacancy);
        }

        // POST api/<PromotionVacancyController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] PromotionVacancyDto PromotionVacancy)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreatePromotionVacancyCommand { PromotionVacancyDto = PromotionVacancy };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PromotionVacancyController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] PromotionVacancyDto PromotionVacancy)
        {
            var command = new UpdatePromotionVacancyCommand { PromotionVacancyDto = PromotionVacancy };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePromotionVacancyCommand { VacancyId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}