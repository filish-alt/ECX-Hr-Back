
using ECX.HR.Application.CQRS.Branch.Request.Command;
using ECX.HR.Application.CQRS.Branch.Request.Queries;

using ECX.HR.Application.DTOs.Branchs;

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
    public class BranchController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BranchController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<BranchController>
        [HttpGet]
        public async Task<ActionResult<List<BranchDto>>> Get()
        {
            var Branch = await _mediator.Send(new GetBranchListRequest());
            return Ok(Branch);
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDto>> Get(Guid id)
        {
            var Branch = await _mediator.Send(new GetBranchDetailRequest { Id = id });
            return Ok(Branch);
        }

        // POST api/<BranchController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] BranchDto Branch)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateBranchCommand { BranchDto = Branch };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] BranchDto Branch)
        {
            var command = new UpdateBranchCommand { BranchDto = Branch };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteBranchCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}