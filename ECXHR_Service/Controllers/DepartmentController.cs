using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.CQRS.Departments.Request.Queries;
using ECX.HR.Application.DTOs.Department;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> Get()
        {
            var departments =await _mediator.Send(new GetDepartmentListRequest());
            return Ok(departments);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<DepartmentDto>>> Get(Guid id)
        {
            var department = await _mediator.Send(new GetDepartmentDetailRequest { DepartmentId = id});
            return Ok(department);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DepartmentDto department)
        {
            var command = new CreateDepartmentCommand { DepartmentDto = department };
            await _mediator.Send(command);
            return Ok(command);

        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] DepartmentDto department)
        {
            var command = new UpdateDepartmentCommand { DepartmentDto = department };
            await _mediator.Send(command);
            return NoContent(); 
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDepartmentCommand { DepartmentId= id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
