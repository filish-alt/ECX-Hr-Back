using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.LeaveBalance.Validator;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using Hangfire.Annotations;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Command
{
    public class CreateOtherLeaveBalanceCommandHandler : IRequestHandler<CreateOtherLeaveBalanceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IOtherLeaveBalanceRepository _otherLeaveBalanceRepository;
    
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeDto _employeeDto;
        private IMapper _mapper;
        public CreateOtherLeaveBalanceCommandHandler(IOtherLeaveBalanceRepository otherLeaveBalanceRepository, IEmployeeRepository employeeRepository,
             EmployeeDto employeeDto, IMapper mapper)
        {
            _otherLeaveBalanceRepository = otherLeaveBalanceRepository;
         
            _employeeRepository = employeeRepository;
            _employeeDto = employeeDto;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateOtherLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new OtherLeaveBalanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OtherLeaveBalanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var otherLeaveBalance = _mapper.Map<OtherLeaveBalances>(request.OtherLeaveBalanceDto);
            otherLeaveBalance.Id = Guid.NewGuid();

            var emp = await _employeeRepository.GetById(otherLeaveBalance.EmpId);

            DateTime employmentStartDate = emp.JoinDate;


            int daysElapsed = 365;


            DateTime currentDate = DateTime.Now;
          
            int yearsOfWork = (currentDate - employmentStartDate).Days / 365;

            otherLeaveBalance.CreatedBy = emp.FirstName;
            otherLeaveBalance.UpdatedBy = emp.FirstName;


           otherLeaveBalance.SickDefaultBalance = 180;
            otherLeaveBalance.SickStartDate = DateTime.MinValue;
            otherLeaveBalance.SickStartDate = DateTime.MinValue;
            otherLeaveBalance.SickRemainingBalance =otherLeaveBalance.SickDefaultBalance;
           otherLeaveBalance.CompassinateDefaultBalance = 3;
           otherLeaveBalance.CompassinateRemainingBalance =otherLeaveBalance.CompassinateDefaultBalance;
           otherLeaveBalance.LeaveWotPayDefaultBalance = 90;
           otherLeaveBalance.LeaveWotPayRemainingBalance =otherLeaveBalance.LeaveWotPayDefaultBalance;
           otherLeaveBalance.EducationDefaultBalance = 5;
           otherLeaveBalance.EducationRemainingBalance =otherLeaveBalance.EducationDefaultBalance;
           otherLeaveBalance.MarriageDefaultBalance = 3;
           otherLeaveBalance.MarriageRemainingBalance =otherLeaveBalance.MarriageDefaultBalance;
            otherLeaveBalance.OtherLeaveRemainingBalance = 0;
            if (emp.sex== "female") { 
           otherLeaveBalance.MaternityDefaultBalance = 120;
           otherLeaveBalance.MaternityRemainingBalance =otherLeaveBalance.MaternityDefaultBalance;
                otherLeaveBalance.AbortionLeaveDefaultBalance = 30;
                otherLeaveBalance.AbortionLeaveRemainingBalance = otherLeaveBalance.AbortionLeaveDefaultBalance;
            }

            else {         otherLeaveBalance.PaternityDefaultBalance = 15;
           otherLeaveBalance.PaternityRemainingBalance =otherLeaveBalance.PaternityDefaultBalance;
            }
   
           otherLeaveBalance.CourtLeaveDefaultBalance = 30;
           otherLeaveBalance.CourtLeaveRemainingBalance =otherLeaveBalance.CourtLeaveDefaultBalance;
           otherLeaveBalance.StartDate = employmentStartDate;  
            otherLeaveBalance.EndDate = employmentStartDate.AddDays(daysElapsed);
            if (yearsOfWork >= 1)
            {
                otherLeaveBalance.StartDate = employmentStartDate.AddYears(yearsOfWork);
                otherLeaveBalance.EndDate = otherLeaveBalance.StartDate.AddDays(360).AddDays(1);

                // Get the previous year's annual balance from the entity 
          

            }

            var data = await _otherLeaveBalanceRepository.Add(otherLeaveBalance);






            response.Success = true;
            response.Message = "Creation Successfull";
            //response.Id = (Guid)add;
            return response;
        }

       
    } }
    
