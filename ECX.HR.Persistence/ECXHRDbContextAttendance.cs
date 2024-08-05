using ECX.HR.Domain;
using ECX.HR.Domain.Common;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ECX.HR.Persistence
{
    public class ECXHRDbContextAttendance : DbContext
    {
        public readonly DbContextOptions<ECXHRDbContextAttendance> _contextAttenda;

        public ECXHRDbContextAttendance(DbContextOptions<ECXHRDbContextAttendance> option) : base(option)
        {
            _contextAttenda = option;
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)


        {


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECXHRDbContextAttendance).Assembly);




            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseDomainEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseDomainEntity.CreatedDate))
                        .HasDefaultValue(DateTime.UtcNow);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseDomainEntity.UpdatedDate))
                        .HasDefaultValue(DateTime.UtcNow);
                }
            }
            modelBuilder.Entity<UserOfNum>()
           .HasNoKey();


            modelBuilder.Entity<NumRunDel>()
        .HasNoKey();


            modelBuilder.Entity<CheckInOut>()
        .HasNoKey();






        

    }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entity.Entity.UpdatedDate = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<NumOfRun> NUM_RUN { get; set; }
        public DbSet<NumRunDel> NUM_RUN_DEIL { get; set; }
        public DbSet<UserOfNum> USER_OF_RUN { get; set; }

        public DbSet<SchClass> SchClass { get; set; }
        public DbSet<USERINFO> USERINFO { get; set; }
        public DbSet<CheckInOut> CHECKINOUT { get; set; }
    
        /*  
          public DbSet<Terminations> Terminations { get; set; }
          public DbSet<Adress> Adress { get; set; }
          public DbSet<AssignSupervisorss> AssignSupervisor { get; set; }
          public DbSet<Department> Departments { get; set; }
          public DbSet<Allowances> Allowance { get; set; }
          public DbSet<Branches> Branch { get; set; }
          public DbSet<DepositAutorizations> DepositAutorizations { get; set; }
          public DbSet<Divisions> Division { get; set; }
          public DbSet<Educations> Education { get; set; }
          public DbSet<EducationLevels> EduactionLevel { get; set; }
          public DbSet<EmergencyContacts> EmergencyContact { get; set; }
          public DbSet<Employees> Employee { get; set; }
          public DbSet<EmployeePositions> EmployeePosition { get; set; }
          public DbSet<EmployeeStatuss> EmploeeStatus { get; set; }
          public DbSet<Levels> Level { get; set; }
          public DbSet<AnnualLeaveBalances> AnnualLeaveBalances { get; set; }
          public DbSet<LeaveTypes> LeaveType { get; set; }
          public DbSet<LeaveRequests> LeaveRequest { get; set; }
          public DbSet<MedicalBalances> MedicalBalance { get; set; }
          public DbSet<Positions> Job { get; set; }
          public DbSet<SalaryTypes> SalaryType { get; set; }
          public DbSet<Spouses> Spouse { get; set; }
          public DbSet<Steps> Step { get; set; }
          public DbSet<Supervisors> Supervisor { get; set; }
          public DbSet<Trainings> Training { get; set; }
          public DbSet<WorkExperiences> WorkExperiences { get; set; }
          public DbSet<OtherLeaveBalances> OtherLeaveBalance { get; set; }
          public DbSet<PromotionVacancys> PromotionVacancys { get; set; }
          public DbSet<Promotions> Promotions { get; set; }
          public DbSet<PromotionRelations> PromotionRelations { get; set; }
          public DbSet<ActingAssigments> ActingAssiment { get; set; }
          public DbSet<Holidays> Holidays { get; set; }
          public DbSet<Attendances> Attendances { get; set; }
          public DbSet<MedicalFunds> MedicalFunds { get; set; }
          public DbSet<MedicalBalances> MedicalBalances { get; set; }
          public DbSet<TempPayrolls> TempPayrolls { get; set; }
          public DbSet<Payrolls> Payrolls { get; set; }
          public DbSet<AllowanceTypes> AllowanceTypes { get; set; }
          public DbSet<Deductions> Deductions { get; set; }
          public DbSet<DeductionTypes> DeductionTypes { get; set; }
          public DbSet<Taxs> Taxs { get; set; }
          public DbSet<Banks> Banks { get; set; }
          public DbSet<OverTimes> OverTimes { get; set; }
          public DbSet<PayrollContracts> PayrollContracts { get; set; }
          public DbSet<ContractEmployees> ContractEmployees { get; set; }

          public DbSet<OutSources> OutSources { get; set; }*/

    }



}
