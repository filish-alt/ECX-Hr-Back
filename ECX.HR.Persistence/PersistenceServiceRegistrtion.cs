
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.ContractS.Persistence;
using ECX.HR.Application.CQRS.LeaveBalance.Handler.Command;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Command;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Response;
using ECX.HR.Persistence.Repositories;
using ECXHR_Service.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence
{
    public static partial class PersistenceServiceRegistrtion
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECXHRDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("staggingConnectionString")));
            services.AddDbContext<ECXHRDbContextAttendance>(options => options.UseSqlServer(configuration.GetConnectionString("attendanceConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAdressRepository, AdressRepository>();
            services.AddScoped<IAllwoanceRepository, AllowanceRepository>();
            services.AddScoped<IBranchRepository, BranchrRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepositAutorizationRepository, DepositAutorizationRepository>();
            services.AddScoped<IDivisionRepository, DivisionRepository>();
            services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEmergencyContactRepository, EmergencyContactRepository>();
            services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IOrganizationalProfileRepository, OrganizationalProfileRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepsitory>();
            services.AddScoped<ISpouseRepository, SpouseRepository>();
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<ISupervisiorRepository, SupervisorRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IAssignSupervisorRepository, AssignSupervisorRepository > ();
            services.AddScoped<ILeaveBalanceRepository,LeaveBalanceRepository>();
            services.AddScoped<IOtherLeaveBalanceRepository, OtherLeaveBalanceRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPromotionRelationRepository, PromotionRelationRepository>();
            services.AddScoped<IMedicalFundRepository, MedicalFundRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<ITerminationRepository, TerminationRepository>();

            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<ICheckInOutRepository, CheckInOutRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IUserOfNumRepository, UserOfNumRepository>();
            services.AddScoped<INumRunRepository, NumOfRunRepository>();
            services.AddScoped<INumOfRunDelRepository, NumRunDelRepository>();
            services.AddScoped<ISchClassRepository, SchRepository>();
            services.AddScoped<IMedicalBalanceRepository, MedicalBalanceRepository>();
            services.AddScoped<IMedicalFundRepository, MedicalFundRepository>();
            services.AddScoped<ITempPayrollRepository, TempPayRollRepository>();
            services.AddScoped<IPayrollRepository, PayRollRepository>();
            services.AddScoped<IAllowanceTypeRepository, AllowanceTypeRepository>();
            services.AddScoped<IDeductionRepository, DeductionRepository>();
            services.AddScoped<IDeductionTypeRepository, DeductionTypeRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IOverTimeRepository, OverTimeRepository>();
            services.AddScoped<IPayrollContractRepository, PayrollContractRepository>();
            services.AddScoped<IContractEmployeesRegstration, ContractEmployeeRepository>();
            services.AddScoped<IAttRepository, AttRepository>();
            services.AddScoped<IOutsourceRepository, OutsourceRepository>();

            services.AddScoped<EmployeeDto>(); // This registers EmployeeDto for dependency injection
         

            services.AddScoped<AnnualLeaveBalanceDto>();

            services.AddScoped<UpdateLeaveBalanceCommandHandler>();
            //services.AddScoped<EmployeeDataServices>();
        

            // Inside ConfigureServices method in Startup.cs
            services.AddScoped<UpdateOtherLeaveBalanceCommandHandler>();
      

            services.AddScoped<IPromotionVacancyRepository, PromotionVacancyRepository>();

            return services;
        }

    }
}
