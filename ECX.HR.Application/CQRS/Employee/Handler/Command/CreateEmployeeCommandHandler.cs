using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Deduction.Request.Command;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.CQRS.Employee.Request.Queries;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command;
using ECX.HR.Application.CQRS.OverTime.Request.Command;
using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.Employees.Validator;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.MedicalBalance;
using ECX.HR.Application.DTOs.OverTime;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Employee.Handler.Command
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IEmployeeRepository _EmployeeRepository;
        private IMapper _mapper;
        private IMediator _mediator;
        public CreateEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IMediator mediator, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
            _mediator = mediator;
            var _employeeLists = new List<Employees>();
    }
        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new EmployeeDtoValidators();
            var validationResult =await validator.ValidateAsync(request.EmployeeDto);
            
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var Employee = _mapper.Map<Employees>(request.EmployeeDto);
            Employee.EmpId = Guid.NewGuid();
            var emp = Employee.EmpId;

            var Empl = await _EmployeeRepository.GetAll();
            var Emp_count = Empl.Count() + 1;
            int Digit_Length = (int)Emp_count.ToString().Length;
            string EcxId_number = Digit_Length >= 4 ? Emp_count.ToString() : Emp_count.ToString("D4");
            DateTime Today = DateTime.Now;
            var Emp_EcxId = "ECX/" + EcxId_number + "/" + Today.Year;
            Employee.EcxId = Emp_EcxId;
            var data =await _EmployeeRepository.Add(Employee);

            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)emp;

            var leaveBalanceDto = new AnnualLeaveBalanceDto
            {
                EmpId = Employee.EmpId, // Set the employee's ID
                                                // ... Set other properties relevant to the leave balance
            };
            var otherLeaveBalanceDto = new OtherLeaveBalanceDto
            {
                EmpId = Employee.EmpId, // Set the employee's ID
                                        // ... Set other properties relevant to the leave balance
            };

            var medicalBalanceDto = new MedicalBalanceDto
            {
                EmpId = Employee.EmpId, // Set the employee's ID
                                        // ... Set other properties relevant to the leave balance
            };

            var overtimeDto = new OverTimeDto
            {
                EmpId = Employee.EmpId, };

            // Create a new instance of CreateLeaveBalanceCommand with the LeaveBalanceDto
            var createLeaveBalanceCommand = new CreateAnnualLeaveBalanceCommand(leaveBalanceDto);
            var createOtherLeaveBalanceCommand = new CreateOtherLeaveBalanceCommand(otherLeaveBalanceDto);
            var createMedicalBalanceCommand = new CreateMedicalBalanceCommand(medicalBalanceDto);
           var createOverTimeCommand = new CreateOverTimeCommand(overtimeDto);

            // Use the Mediator to send the CreateLeaveBalanceCommand to its handler
            var leaveBalanceResponse1 = await _mediator.Send(createLeaveBalanceCommand);
            var otherLeaveBalanceResponse = await _mediator.Send(createOtherLeaveBalanceCommand);
            var medicalBalanceResponse = await _mediator.Send(createMedicalBalanceCommand);
           var overtimeresponse = await _mediator.Send(createOverTimeCommand);


            return response;
        }

    }
}
