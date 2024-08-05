using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Command;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Queries;
using ECX.HR.Application.DTOs.LeaveBalance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveBalance.Handler.Queries
{
    public class GetLeaveBalanceListRequestHandler : IRequestHandler<GetLeaveBalanceListRequest, List<AnnualLeaveBalanceDto>>
    {
        private ILeaveBalanceRepository _LeaveBalanceRepository;
        private IMapper _mapper;
        public GetLeaveBalanceListRequestHandler(ILeaveBalanceRepository LeaveBalanceRepository, IMapper mapper)
        {
            _LeaveBalanceRepository = LeaveBalanceRepository;
            _mapper = mapper;
        }
        public async Task<List<AnnualLeaveBalanceDto>> Handle(GetLeaveBalanceListRequest request, CancellationToken cancellationToken)
        {
            var leaveBalances = await _LeaveBalanceRepository.GetAll();

            var activeLeaveBalances = leaveBalances.Where(leaveBalance => leaveBalance.Status == 0).ToList();


            var expiredLeaveBalances = await _LeaveBalanceRepository.GetExpiredLeaveBalances();

            foreach (var AleaveBalance in expiredLeaveBalances)
            {

                TimeSpan differences = AleaveBalance.EndDate.Subtract(AleaveBalance.StartDate);

                DateTime employmentStartDate = AleaveBalance.EndDate.AddDays(1);

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
                var annualRemaining = AleaveBalance.PreviousYearAnnualBalance + AleaveBalance.PreviousTwoYear + annualleaves;
                AleaveBalance.EmpId = AleaveBalance.EmpId;
                AleaveBalance.StartDate = AleaveBalance.EndDate.AddDays(days);
                AleaveBalance.EndDate = AleaveBalance.EndDate.AddDays(days).AddDays(365);
                AleaveBalance.AnnualDefaultBalance = annualleaves;
                AleaveBalance.PreviousYearAnnualBalance = AleaveBalance.AnnualRemainingBalance;
                AleaveBalance.PreviousTwoYear = AleaveBalance.PreviousYearAnnualBalance;
                AleaveBalance.AnnualRemainingBalance = annualRemaining;

                await _LeaveBalanceRepository.Update(AleaveBalance);

            }
            return _mapper.Map<List<AnnualLeaveBalanceDto>>(activeLeaveBalances);
        }
    }
}