
using ECX.HR.Application.CQRS.Salary.Request.Command;
using ECX.HR.Application.CQRS.Salary.Request.Queries;
using ECX.HR.Application.DTOs.Salaries;

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
    public class SalaryController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SalaryController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<SalaryController>
        [HttpGet]
        public async Task<ActionResult<List<SalaryTypeDto>>> Get()
        {
            var Salary = await _mediator.Send(new GetSalaryListRequest());
            return Ok(Salary);
        }

        // GET api/<SalaryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryTypeDto>> Get(Guid id)
        {
            var Salary = await _mediator.Send(new GetSalaryDetailRequest { Id = id });
            return Ok(Salary);
        }

        // POST api/<SalaryController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] SalaryTypeDto Salary)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateSalaryCommand { SalaryDto = Salary };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<SalaryController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] SalaryTypeDto Salary)
        {
            var command = new UpdateSalaryCommand { SalaryDto = Salary };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteSalaryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}