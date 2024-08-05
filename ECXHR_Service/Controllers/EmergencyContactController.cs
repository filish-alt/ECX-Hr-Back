
using ECX.HR.Application.CQRS.EmergencyContact.Request.Command;
using ECX.HR.Application.CQRS.EmergencyContact.Request.Queries;

using ECX.HR.Application.DTOs.EmergencyContacts;

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
    public class EmergencyContactController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmergencyContactController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<EmergencyContactController>
        [HttpGet]
        public async Task<ActionResult<List<EmergencyContactDto>>> Get()
        {
            var EmergencyContact = await _mediator.Send(new GetEmergencyContactListRequest());
            return Ok(EmergencyContact);
        }

        // GET api/<EmergencyContactController>/5
        [HttpGet("{Empid}")]
        public async Task<ActionResult<EmergencyContactDto>> Get(Guid Empid)
        {
            var EmergencyContact = await _mediator.Send(new GetEmergencyContactDetailRequest { EmpId = Empid });
            return Ok(EmergencyContact);
        }

        // POST api/<EmergencyContactController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] EmergencyContactDto EmergencyContact)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateEmergencyContactCommand { EmergencyContactDto = EmergencyContact };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<EmergencyContactController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] EmergencyContactDto EmergencyContact)
        {
            var command = new UpdateEmergencyContactCommand { EmergencyContactDto = EmergencyContact };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEmergencyContactCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}