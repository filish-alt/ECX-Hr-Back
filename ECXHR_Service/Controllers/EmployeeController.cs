
using ECX.HR.Application.CQRS.Addresss.Request.Queries;
using ECX.HR.Application.CQRS.Education.Request.Queries;
using ECX.HR.Application.CQRS.EmergencyContact.Request.Queries;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.CQRS.Employee.Request.Queries;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Queries;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Queries;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Queries;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Queries;
using ECX.HR.Application.CQRS.Spouse.Request.Queries;
using ECX.HR.Application.CQRS.Training.Request.Queries;
using ECX.HR.Application.CQRS.WorkExperience.Request.Queries;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.Response;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECXHR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> Get()
        {
            var Employee = await _mediator.Send(new GetEmployeeListRequest());
            return Ok(Employee);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(Guid id)
        {
            var Employee = await _mediator.Send(new GetEmployeeDetailRequest { EmpId = id });
            return Ok(Employee);
        }

        [HttpGet("ecx/{EcxId}")]
        public async Task<ActionResult<EmployeeDto>> GetEcxId(string EcxId)
        {
            var Employee = await _mediator.Send(new GetEmployeeHistoryRequest { EcxId = EcxId });
            return Ok(Employee);
        }
        [HttpGet("GetEmployeeData/{id}")]
        public async Task<ActionResult<CombinedEmployeeDataDto>> GetEmployeeData(Guid id)
        {
            try
            {
                // Fetch data from different tables
                var employee = await _mediator.Send(new GetEmployeeDetailRequest { EmpId = id });
                var  addresses  = await _mediator.Send(new GetAddressDetailRequest { EmpId = id });
                var emergencyContacts = await _mediator.Send(new GetEmergencyContactDetailRequest { EmpId = id });
                var employeePostions = await _mediator.Send(new GetEmployeePositionDetailRequest { EmpId = id });
                var educations = await _mediator.Send(new GetEducationDetailRequest { EmpId = id }); ;
                var trainings = await _mediator.Send(new GetTrainingDetailRequest { EmpId = id });
                var leaveRequests = await _mediator.Send(new GetLeaveRequestByIdCommand { EmpId = id });
                var annualLeaveBalances = await _mediator.Send(new GetLeaveBalanceDetailRequest { EmpId = id });
                var otherLeaveBalances = await _mediator.Send(new GetOtherLeaveBalanceDetailRequest { EmpId = id });
                var workExperiences = await _mediator.Send(new GetWorkExperienceDetailRequest { EmpId = id });
                var spouses = await _mediator.Send(new GetSpouseDetailRequest { EmpId = id });
                // Create a CombinedEmployeeDataDto and populate it
                var combinedData = new CombinedEmployeeDataDto
                {
                    Employee = employee ,
                    Addresses = addresses,
                    EmergencyContacts = emergencyContacts ,
                    EmployeePostions = employeePostions,
                    Educations= educations,
                    Trainings= trainings,
                    LeaveRequests=leaveRequests,
                    AnnualLeaveBalances= annualLeaveBalances,
                    OtherLeaveBalances=otherLeaveBalances != null ? otherLeaveBalances : null,
                    WorkExperiences=workExperiences,
                    Spouses= spouses,
                    // Add other data properties as needed
                };

               

                return Ok(combinedData);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, ex.Message);
            }
        }
        // POST api/<EmployeeController>
        [HttpPost]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] EmployeeDto Employee)
        {
            var user = _httpContextAccessor.HttpContext.User;

            var command = new CreateEmployeeCommand { EmployeeDto = Employee };

            var response = await _mediator.Send(command);

            return Ok(response.Id);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]


        public async Task<ActionResult> Put([FromBody] EmployeeDto Employee)
        {
            var command = new UpdateEmployeeCommand { EmployeeDto = Employee };
            await _mediator.Send(command);
            return NoContent();
        }



        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEmployeeCommand { EmpId = id };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}