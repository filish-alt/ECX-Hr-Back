
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Command;
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Queries;
using ECX.HR.Application.DTOs.OrganizationalProfile;
using ECX.HR.Application.DTOs.OrganizationalProfile;
using ECX.HR.Application.DTOs.OrganizationalProfiles;
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
    public class OrganizationalProfileController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrganizationalProfileController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<OrganizationalProfileController>
        [HttpGet]
        public async Task<ActionResult<List<OrganizationalProfileDto>>> Get()
        {
            var OrganizationalProfile = await _mediator.Send(new GetOrganizationalProfileListRequest());
            return Ok(OrganizationalProfile);
        }

        // GET api/<OrganizationalProfileController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationalProfileDto>> Get(Guid id)
        {
            var OrganizationalProfile = await _mediator.Send(new GetOrganizationalProfileDetailRequest { Id = id });
            return Ok(OrganizationalProfile);
        }

        // POST api/<OrganizationalProfileController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody]OrganizationalProfileDto  OrganizationalProfile)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateOrganizationalProfileCommand {OrganizationalProfileDto =OrganizationalProfile };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OrganizationalProfileController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody]OrganizationalProfileDto OrganizationalProfile)
        {
            var command = new UpdateOrganizationalProfileCommand {OrganizationalProfileDto =OrganizationalProfile };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteOrganizationalProfileCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}