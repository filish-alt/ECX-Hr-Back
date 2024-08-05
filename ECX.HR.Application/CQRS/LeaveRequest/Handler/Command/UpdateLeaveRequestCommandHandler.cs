using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.DTOs.LeaveRequest.validator;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.CQRS.LeaveRequest.Handler.Command;
using ECX.HR.Application.DTOs.LeaveBalance;

namespace ECX.HR.Application.CQRS.LeaveRequest.Handler.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IOtherLeaveBalanceRepository _otherLeaveBalanceRepository;
        private readonly ILeaveBalanceRepository _LeaveBalanceRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _maapper;
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,IHolidayRepository holidayRepository ,ILeaveTypeRepository leaveTypeRepository, IOtherLeaveBalanceRepository otherLeaveBalanceRepository, IMapper maapper, IEmployeeRepository employeeRepository, ILeaveBalanceRepository leaveBalanceRepository)
        {

            _leaveRequestRepository = leaveRequestRepository;
            _holidayRepository = holidayRepository;
            _otherLeaveBalanceRepository = otherLeaveBalanceRepository;
            _LeaveBalanceRepository = leaveBalanceRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _maapper = maapper;
            _employeeRepository = employeeRepository;

        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new LeaveRequestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.LeaveRequestDto.UpdatedDate = DateTime.Now;
            var leaveRequest = await _leaveRequestRepository.GetById(request.LeaveRequestDto.leaveRequestId);
          

            _maapper.Map(request.LeaveRequestDto, leaveRequest);


            var leaveTypes = await _leaveTypeRepository.GetAll();
            var leaveType = leaveTypes.FirstOrDefault(lt => lt.leaveTypeId == request.LeaveRequestDto.leaveTypeId);



            if (request.LeaveRequestDto.LeaveStatus == "Admin-Approved" && leaveType.LeaveTypeName == "Annual")
            {
                var leaveStartDate = leaveRequest.StartDate;
                var leaveEndDate = leaveRequest.EndDate;

                var totalDuration = (decimal)(leaveEndDate - leaveStartDate).TotalDays + 1;

          
                decimal holidaysAndWeekends = 0;

             
                var holidays = await _holidayRepository.GetHolidaysFromTable(leaveStartDate, leaveEndDate);

               
                for (DateTime date = leaveStartDate; date <= leaveEndDate; date = date.AddDays(1))
                {
                    
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        holidaysAndWeekends++;
                    }
                    else
                    {
                          if (holidays.Any(holiday => holiday.Date.Date == date.Date))
                        {
                            holidaysAndWeekends++;
                        }
                    }
                }

                 Decimal leaveDuration = totalDuration - holidaysAndWeekends;

                Double Diff = Convert.ToDouble(leaveDuration - leaveRequest.WorkingDays);

                if (Diff < 0.5)
                {
                    leaveDuration = leaveRequest.WorkingDays;
                }

                var employeeId = request.LeaveRequestDto.EmpId;
                var otherLeaveBalances = await _otherLeaveBalanceRepository.GetByEmpId(employeeId);
                var leaveBalances = await _LeaveBalanceRepository.GetByEmpId(employeeId);

                var employee = await _employeeRepository.GetById(employeeId);
                DateTime employmentStartDate = employee.JoinDate;
                DateTime currentDate = DateTime.Now;
                int daysElapsed = 365;
                int yearsOfWork = (currentDate - employmentStartDate).Days / 365;
                int baseLeaveDay = 18 + (yearsOfWork - 1);

                int totalDaysInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;
                TimeSpan timeWorked = currentDate - employmentStartDate.AddYears(yearsOfWork);
                int daysWorkedInYear = (int)timeWorked.TotalDays;
                int accruedLeave = (int)Math.Round(baseLeaveDay * (double)daysWorkedInYear / totalDaysInYear);


                foreach (var leaveBalance in leaveBalances.OrderBy(lb => lb.StartDate))
                {

                    leaveBalance.TotalRequest += leaveDuration;
                    Decimal remainingLeave = leaveBalance.TotalRemaining - leaveBalance.TotalRequest;

                    leaveBalance.TotalRemaining = Math.Max(0, remainingLeave);

                    if (leaveBalance.IsExpired != 1)
                    {
                        var annualRemainingBalance = (leaveBalance.PreviousTwoYear + leaveBalance.PreviousYearAnnualBalance + leaveBalance.AnnualDefaultBalance) - leaveDuration;
                       // leaveBalance.AnnualRemainingBalance = annualRemainingBalance;
                        if (leaveDuration > 0)
                        {
                            //eaveType = leaveTypes.FirstOrDefault(lt => lt.leaveTypeId == request.LeaveRequestDto.leaveTypeId);
                            if (leaveType != null)
                            {
                                if (leaveType.LeaveTypeName == "Annual" && leaveDuration <= annualRemainingBalance)
                                {
                                    if (leaveBalance.PreviousTwoYear > 0 && leaveDuration < leaveBalance.PreviousTwoYear)
                                    {
                                        leaveBalance.PreviousTwoYear = Math.Max(0, leaveBalance.PreviousTwoYear - leaveDuration);
                                        var remaining = leaveBalance.AnnualRemainingBalance - leaveDuration;
                                        leaveBalance.AnnualRemainingBalance = remaining;
                                    }
                                    if (leaveBalance.PreviousTwoYear > 0 && leaveDuration > leaveBalance.PreviousTwoYear)
                                    {
                                        var previousleave = leaveBalance.PreviousYearAnnualBalance + leaveBalance.PreviousTwoYear;
                                        previousleave -= leaveDuration;
                                        leaveBalance.PreviousYearAnnualBalance = previousleave;
                                        leaveBalance.PreviousTwoYear = 0;
                                        var remaining = leaveBalance.AnnualRemainingBalance - leaveDuration;
                                        leaveBalance.AnnualRemainingBalance = remaining;
                                    }
                                    if (leaveBalance.PreviousTwoYear == 0  && leaveBalance.PreviousYearAnnualBalance > leaveDuration)
                                    {
                                        leaveBalance.PreviousYearAnnualBalance -= leaveDuration;
                                        leaveBalance.AnnualRemainingBalance -= leaveDuration;
                                    }
                                    if (leaveDuration > leaveBalance.PreviousYearAnnualBalance)

                                    {
                                        var previousleave = leaveBalance.PreviousYearAnnualBalance + leaveBalance.AnnualRemainingBalance;
                                        previousleave -= leaveDuration;
                                       
                                        leaveBalance.AnnualRemainingBalance = previousleave;
                                        leaveBalance.PreviousYearAnnualBalance = 0;
                                    }
                                }
                            }

                        }
                        leaveRequest.ApprovedBy = request.LeaveRequestDto.Supervisor;
                        leaveRequest.ApproveDate = currentDate;
                        await _leaveRequestRepository.Update(leaveRequest);
                        await _LeaveBalanceRepository.Update(leaveBalance);
                    }

                }

            }
            else if (request.LeaveRequestDto.LeaveStatus == "Admin-Approved" && leaveType.LeaveTypeName != "Annual")
            {
                var leaveStartDate = leaveRequest.StartDate;
                var leaveEndDate = leaveRequest.EndDate;

                var totalDuration = (decimal)(leaveEndDate - leaveStartDate).TotalDays + 1;


                decimal holidaysAndWeekends = 0;


                var holidays = await _holidayRepository.GetHolidaysFromTable(leaveStartDate, leaveEndDate);


                for (DateTime date = leaveStartDate; date <= leaveEndDate; date = date.AddDays(1))
                {

                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        holidaysAndWeekends++;
                    }
                    else
                    {
                        if (holidays.Any(holiday => holiday.Date.Date == date.Date))
                        {
                            holidaysAndWeekends++;
                        }
                    }
                }

                var leaveDuration = totalDuration - holidaysAndWeekends;
                if (leaveDuration > leaveRequest.WorkingDays)
                {
                    leaveDuration = leaveRequest.WorkingDays;
                }
                var employeeId = request.LeaveRequestDto.EmpId;
                var otherLeaveBalances = await _otherLeaveBalanceRepository.GetByEmpId(employeeId);
                var employee = await _employeeRepository.GetById(employeeId);




                foreach (var otherLeaveBalance in otherLeaveBalances.OrderBy(lb => lb.StartDate))
                {
                    if (otherLeaveBalance.IsExpired != 1)
                    {

                        var sickRemainingBalance = otherLeaveBalance.SickRemainingBalance;
                        var paternityRemainingBalance = otherLeaveBalance.PaternityRemainingBalance;
                        var maternityRemainingBalance = otherLeaveBalance.MaternityRemainingBalance;
                        var marraiageRemainingBalance = otherLeaveBalance.MarriageRemainingBalance;
                        var educationRemainingBalance = otherLeaveBalance.EducationRemainingBalance;
                        var compassinateRemainingBalance = otherLeaveBalance.CompassinateRemainingBalance;
                        var courtLeaveRemainingBalance = otherLeaveBalance.CourtLeaveRemainingBalance;
                        var leaveWotPayRemainingBalance = otherLeaveBalance.LeaveWotPayRemainingBalance;
                        var abortionRemainingBalance = otherLeaveBalance.AbortionLeaveRemainingBalance;
                        var otherRemainingBalance = otherLeaveBalance.OtherLeaveRemainingBalance;
                        if (leaveDuration > 0)
                        {
                            DateTime currentDate = DateTime.Now;

                            if (leaveType != null)
                            {
                                if (leaveType.LeaveTypeName == "Sick" && totalDuration <= sickRemainingBalance)
                                {
                                    otherLeaveBalance.SickRemainingBalance -= totalDuration;
                                    leaveDuration = 0;
                                    if (otherLeaveBalance.SickEndDate == DateTime.MinValue)
                                    {
                                        otherLeaveBalance.SickEndDate = leaveRequest.StartDate.AddDays(366);
                                        otherLeaveBalance.SickStartDate = leaveRequest.StartDate;

                                    }

                                }
                                else if (leaveType.LeaveTypeName == "Abortion" && leaveDuration <= abortionRemainingBalance && employee.sex == "female")
                                {
                                    otherLeaveBalance.AbortionLeaveRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Maternal" && leaveDuration <= maternityRemainingBalance && employee.sex=="female")
                                {
                                    otherLeaveBalance.MaternityRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Paternal" && leaveDuration <= paternityRemainingBalance && employee.sex == "male")
                                {
                                    otherLeaveBalance.PaternityRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Education" && leaveDuration <= educationRemainingBalance)
                                {
                                    otherLeaveBalance.EducationRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Marriage" && leaveDuration <= marraiageRemainingBalance)
                                {
                                    otherLeaveBalance.MarriageRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Compassinate" && leaveDuration <= compassinateRemainingBalance)
                                {
                                    otherLeaveBalance.CompassinateRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Court" && leaveDuration <= courtLeaveRemainingBalance)
                                {
                                    otherLeaveBalance.CourtLeaveRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "Leave With Out Pay" && leaveDuration <= leaveWotPayRemainingBalance)
                                {
                                    otherLeaveBalance.LeaveWotPayRemainingBalance -= leaveDuration;
                                    leaveDuration = 0;
                                }
                                else if (leaveType.LeaveTypeName == "OtherLeave" )
                                {
                                    otherLeaveBalance.OtherLeaveRemainingBalance = 0;
                                    leaveDuration = 0;
                                }
                                otherLeaveBalance.SickEndDate = otherLeaveBalance.SickEndDate;
                                otherLeaveBalance.SickEndDate = otherLeaveBalance.SickStartDate;
                                leaveRequest.ApprovedBy = request.LeaveRequestDto.Supervisor;
                             leaveRequest.ApproveDate = currentDate;
                                await _otherLeaveBalanceRepository.Update(otherLeaveBalance);
                                await _leaveRequestRepository.Update(leaveRequest);
                            }
                            else
                            {

                                break;
                            }
                        }
                    }

                  
                }

            }
            await _leaveRequestRepository.Update(leaveRequest);
            
            return Unit.Value;
        }

    }
}
                    










