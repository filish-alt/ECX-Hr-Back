
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.CQRS.Addresss.Request.Queries;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Command;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Queries;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.DTOs.Addresss;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.PayrollContract;
using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AddressController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> Get()
        {
            var address = await _mediator.Send(new GetAddressListRequest());
            return Ok(address);
        }

        /*       [HttpGet("{Empid}")]
               public async Task<ActionResult<EmployeeDto>> GetByEmpId(Guid Empid)
               {
                   var address = await _mediator.Send(new GetAddressDetailRequest { EmpId = Empid });
                   return Ok(address);
               }*/
        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AddressDto address)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateAddressCommand { AdressDetailDto = address };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult> Put([FromBody] AddressDto address)
        {
            var command = new UpdateAddressCommand { AddressDto = address };
            //_context.Entry(existingEvent).Property(x => x.ReferenceNumber).IsModified = false;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAddressCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}