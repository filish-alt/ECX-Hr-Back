
using ECX.HR.Application.CQRS.AssignSupervisor.Request.Command;
using ECX.HR.Application.CQRS.AssignSupervisor.Request.Queries;

using ECX.HR.Application.DTOs.AssignSupervisor;
using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignSupervisorController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AssignSupervisorController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AssignSupervisorController>
        [HttpGet]
        public async Task<ActionResult<List<AssignSupervisorDto>>> Get()
        {
            var AssignSupervisor = await _mediator.Send(new GetAssignSupervisorListRequest());
            return Ok(AssignSupervisor);
        }
        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignSupervisorDto>> Get(Guid id)
        {
            var Branch = await _mediator.Send(new GetAssignSupervisorDetailRequest { Id = id });
            return Ok(Branch);
        }


        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AssignSupervisorDto AssignSupervisor)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateAssignSupervisorCommand { AssignSupervisorDetailDto = AssignSupervisor };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AssignSupervisorController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] AssignSupervisorDto AssignSupervisor)
        {
            var command = new UpdateAssignSupervisorCommand { AssignSupervisorDto = AssignSupervisor };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAssignSupervisorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}