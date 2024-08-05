/*using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveBalance.Handler.Command;
using ECX.HR.Application.CQRS.LeaveBalance.Request.Command;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Models;
using ECX.HR.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApplication.BackgroundServices
{
    public class DailyFunctionService : BackgroundService
    {
        private readonly UpdateLeaveBalanceCommandHandler _updateLeaveBalanceCommandHandler;
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private IMapper _mapper;

        public DailyFunctionService(

            IServiceScopeFactory serviceScopeFactory
           )
        {
            _serviceScopeFactory = serviceScopeFactory;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                while (!stoppingToken.IsCancellationRequested)
                {

                    var updateLeaveBalanceHandler = scope.ServiceProvider.GetRequiredService<UpdateLeaveBalanceCommandHandler>();
                    var leaveBalanceRepository = scope.ServiceProvider.GetRequiredService<ILeaveBalanceRepository>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                    var expiredLeaveBalances = await leaveBalanceRepository.GetExpiredLeaveBalances();

                    foreach (var leaveBalance in expiredLeaveBalances)
                    {

                        TimeSpan differences = leaveBalance.EndDate.Subtract(leaveBalance.StartDate);

                        DateTime employmentStartDate = leaveBalance.EndDate.AddDays(1);

                        int yearsOfWork = (DateTime.Now - employmentStartDate).Days / 365;
                        int maxLeaveDays = 30;
                        int baseLeaveDays = 18+ yearsOfWork;
                        int additionalLeavePerYear = 1;

                        DateTime currentDate = DateTime.Now;

                        int totalDaysInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;

                        TimeSpan timeWorkeds = currentDate - (leaveBalance.EndDate.AddDays(1));

                        int daysWorkeds = (int)timeWorkeds.TotalDays;

                        int totalbaseLeaveDays = baseLeaveDays + Math.Min(yearsOfWork - 1, maxLeaveDays - baseLeaveDays) * additionalLeavePerYear;
                        int accruedLeaves = (int)Math.Round(totalbaseLeaveDays * (double)daysWorkeds / totalDaysInYear);

                        int annualleaves = Math.Min(accruedLeaves, maxLeaveDays);
                        int daysDifferences = differences.Days;
                        int days = 1;
*//*
                        var updatedDto = mapper.Map<LeaveBalanceDto>(leaveBalance);
                   
                        updatedDto.EmpId = leaveBalance.EmpId;
                        updatedDto.StartDate = leaveBalance.EndDate.AddDays(days);
                        updatedDto.EndDate = leaveBalance.EndDate.AddDays(days).AddDays(365);
                        updatedDto.AnnualDefaultBalance = annualleaves;

                     
                        updatedDto.SickDefaultBalance = leaveBalance.SickDefaultBalance;
                        updatedDto.SickRemainingBalance = leaveBalance.SickRemainingBalance;
                    
                        updatedDto.CompassinateDefaultBalance = leaveBalance.CompassinateDefaultBalance;
                        updatedDto.CompassinateRemainingBalance = leaveBalance.CompassinateRemainingBalance;
                        updatedDto.LeaveWotPayDefaultBalance = 90;
                        updatedDto.LeaveWotPayRemainingBalance = 90;
                        updatedDto.EducationDefaultBalance =5;
                        updatedDto.EducationRemainingBalance = 5;
                        updatedDto.MarriageDefaultBalance = leaveBalance.MarriageDefaultBalance;
                        updatedDto.MarraiageRemainingBalance = leaveBalance.MarraiageRemainingBalance;
                        updatedDto.MaternityDefaultBalance = leaveBalance.MaternityDefaultBalance;
                        updatedDto.MaternityRemainingBalance = leaveBalance.MarraiageRemainingBalance;
                        updatedDto.PaternityDefaultBalance = leaveBalance.PaternityDefaultBalance;
                        updatedDto.PaternityRemainingBalance = leaveBalance.PaternityRemainingBalance;
                        updatedDto.CourtLeaveDefaultBalance = leaveBalance.CourtLeaveDefaultBalance;
                        updatedDto.CourtLeaveRemainingBalance = leaveBalance.CourtLeaveRemainingBalance;
                        updatedDto.PreviousYearAnnualBalance = leaveBalance.AnnualDefaultBalance;
                        updatedDto.AnnualRemainingBalance = leaveBalance.PreviousYearAnnualBalance + annualleaves;




                        var updateCommand = new UpdateLeaveBalanceCommand
                        {
                            LeaveBalanceDto = updatedDto
                        };

                        await updateLeaveBalanceHandler.Handle(updateCommand, stoppingToken);

                        Console.WriteLine($"Updated leave balance with ID {leaveBalance.Id}");
                    }
                    var leaveBalances = await leaveBalanceRepository.GetAll();
                    foreach (var leaveBalance in leaveBalances)
                    {

                        var updatedDtos = mapper.Map<LeaveBalanceDto>(leaveBalance);




                        DateTime employmentStartDate = leaveBalance.StartDate;
                   
                        int daysElapsed = 365;
                        var ed = employmentStartDate.AddDays(daysElapsed);

                        TimeSpan difference = ed.Subtract(employmentStartDate);
                        int daysDifference = difference.Days;


                        DateTime currentDate = DateTime.Now;

                        int yearsOfWork = (currentDate - employmentStartDate).Days / 365;
                        int maxLeaveDays = 30;
                        int baseLeaveDay = 18 + yearsOfWork;

                        int baseLeaveDays = Math.Min(baseLeaveDay, 30);

                        int totalDaysInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;

                        TimeSpan timeWorked = currentDate - employmentStartDate.AddYears(yearsOfWork); ;
                        int daysWorkedInYear = (int)timeWorked.TotalDays;
                        int accruedLeave = (int)Math.Round(baseLeaveDays * (double)daysWorkedInYear / totalDaysInYear);

                        int annualLeave = Math.Min(accruedLeave, maxLeaveDays);

                        updatedDtos.AnnualDefaultBalance = annualLeave;
                        updatedDtos.AnnualRemainingBalance = annualLeave + leaveBalance.PreviousYearAnnualBalance;






                        if (leaveBalance.SickEndDate <= currentDate)
                        {
                            updatedDtos.SickEndDate = DateTime.MinValue; 

                            updatedDtos.SickRemainingBalance = 180;
                            updatedDtos.SickRemainingBalance = 180;
                        }


                        if (leaveBalance.CompassinateRemainingBalance == 0)
                        {
                            updatedDtos.CompassinateRemainingBalance = 3;
                            updatedDtos.CompassinateDefaultBalance = 3;
                        }

                        if (leaveBalance.MarraiageRemainingBalance == 0)
                        {
                            updatedDtos.MarriageDefaultBalance = 3;
                            updatedDtos.MarraiageRemainingBalance = 3;
                        }
                        if (leaveBalance.MaternityRemainingBalance == 0)
                        {
                            updatedDtos.MaternityDefaultBalance = 120;
                            updatedDtos.MaternityRemainingBalance = 120;
                        }
                        if(leaveBalance.PaternityRemainingBalance == 0)
                        {
                            updatedDtos.PaternityRemainingBalance = 7;
                            updatedDtos.PaternityRemainingBalance = 7;
                        }


                

                        if (leaveBalance.CourtLeaveRemainingBalance == 0)
                        {
                            updatedDtos.CourtLeaveDefaultBalance = 0;
                            updatedDtos.CourtLeaveRemainingBalance = 0;
                        }



                        var updateCommands = new UpdateLeaveBalanceCommand
                        {
                            LeaveBalanceDto = updatedDtos
                        };

                        await updateLeaveBalanceHandler.Handle(updateCommands, stoppingToken);

                        Console.WriteLine($"Updated leave balancessss with ID {leaveBalance.Id}");
                    }

                }*//*

                Console.WriteLine("Working...");

                await Task.Delay(TimeSpan.FromHours(0.016), stoppingToken);
            }

        }
    }
}
*/