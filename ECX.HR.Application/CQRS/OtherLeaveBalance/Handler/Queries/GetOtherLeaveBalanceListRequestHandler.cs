using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Command;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Command;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Queries;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Queries
{
    public class GetOtherLeaveBalanceListRequestHandler : IRequestHandler<GetOtherLeaveBalanceListRequest, List<OtherLeaveBalanceDto>>
    {
        private IOtherLeaveBalanceRepository _otherLeaveBalanceRepository;
        private IMapper _mapper;
        private readonly ILeaveBalanceRepository _LeaveBalanceRepository;

        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEmployeeRepository _employeeRepository;
        public GetOtherLeaveBalanceListRequestHandler(IOtherLeaveBalanceRepository OtherLeaveBalanceRepository, IMapper mapper, IEmployeeRepository employeeRepository, ILeaveBalanceRepository LeaveBalanceRepository)
        {
            _otherLeaveBalanceRepository = OtherLeaveBalanceRepository;
            _mapper = mapper;
            _LeaveBalanceRepository = LeaveBalanceRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<List<OtherLeaveBalanceDto>> Handle(GetOtherLeaveBalanceListRequest request, CancellationToken cancellationToken)
        {
        
            var expiredOtherLeaveBalances = await _otherLeaveBalanceRepository.GetExpiredOtherLeaveBalances();
            var expiredLeaveBalances = await _LeaveBalanceRepository.GetExpiredLeaveBalances();
            foreach (var AleaveBalance in expiredLeaveBalances)
            {

                TimeSpan differences = AleaveBalance.EndDate.Subtract(AleaveBalance.StartDate);

                var employee = await _employeeRepository.GetById(AleaveBalance.EmpId);
                DateTime employmentStartDate = employee.JoinDate;

                int yearsOfWork = (DateTime.Now - employmentStartDate).Days / 365;
                int maxLeaveDays = 30;
                int baseLeaveDays = 18 + yearsOfWork;
                int additionalLeavePerYear = 1;

                DateTime currentDate = DateTime.Now;

                int totalDaysInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;

                TimeSpan timeWorkeds = currentDate - (AleaveBalance.EndDate.AddDays(1));

                int daysWorkeds = (int)timeWorkeds.TotalDays;

                int totalbaseLeaveDays = baseLeaveDays + Math.Min(yearsOfWork - 1, maxLeaveDays - baseLeaveDays) * additionalLeavePerYear;
                int accruedLeaves = (int)Math.Round(totalbaseLeaveDays * (double)daysWorkeds / totalDaysInYear);

                int annualleaves = Math.Min(accruedLeaves, maxLeaveDays);
                int daysDifferences = differences.Days;
                int days = 1;

                var updatedDto = _mapper.Map<AnnualLeaveBalanceDto>(AleaveBalance);
                var annualRemaining = AleaveBalance.PreviousYearAnnualBalance + AleaveBalance.PreviousTwoYear + AleaveBalance.AnnualDefaultBalance;
                AleaveBalance.EmpId = AleaveBalance.EmpId;
                AleaveBalance.StartDate = AleaveBalance.EndDate.AddDays(days);
                AleaveBalance.EndDate = AleaveBalance.EndDate.AddDays(days).AddDays(365);
                AleaveBalance.PreviousTwoYear = AleaveBalance.PreviousYearAnnualBalance; 
                AleaveBalance.PreviousYearAnnualBalance = AleaveBalance.AnnualDefaultBalance;
                AleaveBalance.AnnualDefaultBalance = annualleaves;
          
             
                AleaveBalance.AnnualRemainingBalance = annualRemaining;

                await _LeaveBalanceRepository.Update(AleaveBalance);

            }
            var OtherLeaveBalances = await _otherLeaveBalanceRepository.GetAll();
            var LeaveBalances = await _LeaveBalanceRepository.GetAll();


            foreach (var LeaveBalance in LeaveBalances)
            {
                var employee = await _employeeRepository.GetById(LeaveBalance.EmpId);
                DateTime employmentStartDate = employee.JoinDate;
                DateTime currentDate = DateTime.Now;
                int daysElapsed = 365;
                var ed = employmentStartDate.AddDays(daysElapsed);

                TimeSpan difference = ed.Subtract(employmentStartDate);
                int daysDifference = difference.Days;




                int yearsOfWork = (currentDate - employmentStartDate).Days / 365;
                int maxLeaveDays = 30;
                int baseLeaveDay = 18 + (yearsOfWork - 1);

                int baseLeaveDays = Math.Min(baseLeaveDay, 30);

                int totalDaysInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;


                TimeSpan timeWorked = currentDate - employmentStartDate.AddYears(yearsOfWork);


                int daysWorkedInYear = (int)timeWorked.TotalDays;
                int accruedLeave = (int)Math.Round(baseLeaveDays * (double)daysWorkedInYear / totalDaysInYear);

                int annualLeave = Math.Min(accruedLeave, maxLeaveDays);

     
                
                var annualRemaining = LeaveBalance.PreviousYearAnnualBalance + LeaveBalance.PreviousTwoYear + LeaveBalance.AnnualDefaultBalance;
                LeaveBalance.AnnualRemainingBalance = LeaveBalance.AnnualRemainingBalance - LeaveBalance.AnnualDefaultBalance + annualLeave;
                LeaveBalance.AnnualDefaultBalance = annualLeave;

             

                await _LeaveBalanceRepository.Update(LeaveBalance);
            }
            foreach (var otherLeaveBalance in expiredOtherLeaveBalances)
            {
               
                var updatedDto = _mapper.Map<OtherLeaveBalanceDto>(otherLeaveBalance);

                DateTime employmentStartDate = otherLeaveBalance.EndDate;

                int daysElapsed = 365;
                var ed = employmentStartDate.AddDays(daysElapsed);


                DateTime currentDate = DateTime.Now;


                int totalDaysInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;

                otherLeaveBalance.EndDate = ed;
                otherLeaveBalance.StartDate = employmentStartDate;
                otherLeaveBalance.LeaveWotPayDefaultBalance =90;
                otherLeaveBalance.LeaveWotPayRemainingBalance =90;
                otherLeaveBalance.EducationDefaultBalance =5;
                otherLeaveBalance.EducationRemainingBalance =5;

                await _otherLeaveBalanceRepository.Update(otherLeaveBalance);
            }


            foreach (var otherLeaveBalance in OtherLeaveBalances)
            {
                var employee = await _employeeRepository.GetById(otherLeaveBalance.EmpId);


                DateTime currentDate = DateTime.Now;



                if (otherLeaveBalance.SickEndDate <= currentDate)
                {
                    otherLeaveBalance.SickEndDate = DateTime.MinValue;
                    otherLeaveBalance.SickStartDate = DateTime.MinValue;

                    otherLeaveBalance.SickRemainingBalance = 180;
                    otherLeaveBalance.SickRemainingBalance = 180;
                }


                if (otherLeaveBalance.CompassinateRemainingBalance == 0)
                {
                    otherLeaveBalance.CompassinateRemainingBalance = 3;
                    otherLeaveBalance.CompassinateDefaultBalance = 3;
                }
                if (otherLeaveBalance.AbortionLeaveRemainingBalance== 0 && employee.sex == "Female")
                {
                    otherLeaveBalance.AbortionLeaveRemainingBalance = 30;
                    otherLeaveBalance.AbortionLeaveDefaultBalance = 30;
                }

                if (otherLeaveBalance.MarriageRemainingBalance == 0)
                {
                    otherLeaveBalance.MarriageDefaultBalance = 3;
                    otherLeaveBalance.MarriageRemainingBalance = 3;
                }
                if (otherLeaveBalance.MaternityRemainingBalance == 0 && employee.sex=="Female")
                {
                    otherLeaveBalance.MaternityDefaultBalance = 120;
                    otherLeaveBalance.MaternityRemainingBalance = 120;
                }
                if (otherLeaveBalance.PaternityRemainingBalance == 0 && employee.sex == "Male")
                {
                    otherLeaveBalance.PaternityRemainingBalance = 7;
                    otherLeaveBalance.PaternityRemainingBalance = 7;
                }


                if (otherLeaveBalance.CourtLeaveRemainingBalance == 0)
                {
                    otherLeaveBalance.CourtLeaveDefaultBalance = 30;
                    otherLeaveBalance.CourtLeaveRemainingBalance = 30;
                }


                await _otherLeaveBalanceRepository.Update(otherLeaveBalance);
                Console.WriteLine($"Updated leave balance with ID {otherLeaveBalance.Id}");
            }



     var activeOtherLeaveBalances = OtherLeaveBalances.Where(OtherLeaveBalance => OtherLeaveBalance.Status == 0).ToList();

            return _mapper.Map<List<OtherLeaveBalanceDto>>(activeOtherLeaveBalances);
        }
    }
}
    