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
    public class ECXHRDbContext : DbContext
    {
        public readonly DbContextOptions<ECXHRDbContext> _context;

        public ECXHRDbContext(DbContextOptions<ECXHRDbContext> options) : base(options)
        {
            _context = options;
        }


        public async Task<List<SchClass>> GetTable1DataFromSourceDatabase()
        {
            var result = this.Set<SchClass>().FromSqlInterpolated($"EXEC GetSpecificDataFromatt2000SQL").ToList();
            return result;
        }
        public async Task<List<UserOfNum>> GetUserOfNumFromSourceDatabase(int USERID)
        {
            var result = this.Set<UserOfNum>().FromSqlInterpolated($"EXEC GetUserOfRun @USERID={USERID}").ToList();
            return result;
        }
        public async Task<List<CheckInOut>> GetCheckInOutFromSourceDatabase(int user, DateTime? CheckIn, DateTime? CheckOut)
        {
            DateTime start = CheckIn.Value.Date;
            DateTime end = CheckOut.Value.Date;

            var result = this.Set<CheckInOut>().FromSqlInterpolated($"EXEC GetCheckInOut  @USERID={user}, @STARTIN={start}, @ENDOUT={end}").ToList();
            return result;
        }
        public async Task<List<USERINFO>> GetUserInfoDataFromSourceDatabase()
        {
            var result = this.Set<USERINFO>()
                           .FromSqlInterpolated($"EXEC GetUserInformation ")
                           .ToList();
            return result;
        }
        public async Task<List<NumOfRun>> GetNumOfRunDataFromSourceDatabase()
        {
            var result = this.Set<NumOfRun>().FromSqlInterpolated($"EXEC NumOfRuns").ToList();
            return result;
        }
        public async Task<List<NumRunDel>> GetNumRunDelDataFromSourceDatabase()
        {
            var result = this.Set<NumRunDel>().FromSqlInterpolated($"EXEC NumOfRunDels").ToList();
            return result;
        }
        public async Task<List<CheckInOut>> GetCheckInOutByDate(DateTime? date)
        {
            var result = this.Set<CheckInOut>().FromSqlInterpolated($"EXEC GetCheckInOutByDate @DATE={date}").ToList();
            return result;
        }

        /*      using (var context = new ECXHRDbContext(_context))
       {
           context.DeductionTypes.AddRange(FixedDeductioType14, FixedDeductioType13, FixedDeductioType12, FixedDeductioType11, FixedDeductioType10, FixedDeductioType9,
               FixedDeductioType8, FixedDeductioType7, FixedDeductioType6, FixedDeductioType5, FixedDeductioType4, FixedDeductioType3, FixedDeductioType2, FixedDeductioType1);
           context.SaveChanges();
       }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)


        {
 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECXHRDbContext).Assembly);
            modelBuilder.Entity<Adress>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Allowances>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Branches>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Department>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<DepositAutorizations>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Divisions>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<EducationLevels>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Educations>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<EmergencyContacts>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<EmployeePositions>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Employees>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<EmployeeStatuss>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Levels>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<AnnualLeaveBalances>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<OrganizationalProfiles>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Positions>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<SalaryTypes>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Spouses>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Steps>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Supervisors>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Trainings>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<WorkExperiences>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<AssignSupervisorss>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<LeaveTypes>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<LeaveRequests>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<OtherLeaveBalances>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<PromotionVacancys>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<PromotionRelations>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<ActingAssigments>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Holidays>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<MedicalFunds>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<MedicalBalances>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<TempPayrolls>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Payrolls>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<AllowanceTypes>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Deductions>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<DeductionTypes>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Taxs>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Banks>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<OverTimes>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<PayrollContracts>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<ContractEmployees>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<OutSources>().Property(c => c.PId).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

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





            modelBuilder.Entity<Employees>()
            .HasMany(e => e.WorkExperiences)
            .WithOne(ex => ex.Employees)
            .HasForeignKey(e => e.EmpId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employees>()
            .HasMany(e => e.Educations)
            .WithOne(ex => ex.Employees)
            .HasForeignKey(e => e.EmpId)
              .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<Employees>()
            .HasMany(e => e.Trainings)
            .WithOne(ex => ex.Employees)
            .HasForeignKey(e => e.EmpId)
              .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<Employees>()
           .HasMany(e => e.EmergencyContacts)
           .WithOne(ex => ex.Employees)
           .HasForeignKey(e => e.EmpId)
             .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Employees>()
            .HasMany(e => e.Spouses)
            .WithOne(ex => ex.Employees)
            .HasForeignKey(e => e.EmpId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employees>()
     .HasMany(e => e.Promotions)
     .WithOne(ex => ex.Employees)
     .HasForeignKey(e => e.EmpId)
       .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Employees>()
            .HasMany(e => e.LeaveBalances)
            .WithOne(ex => ex.Employees)
            .HasForeignKey(e => e.EmpId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employees>()
        .HasMany(e => e.Terminations)
        .WithOne(ex => ex.Employees)
        .HasForeignKey(e => e.EmpId)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employees>()
        .HasMany(e => e.PromotionRelations)
        .WithOne(ex => ex.Employees)
        .HasForeignKey(e => e.EmpId)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
            .HasMany(e => e.Divisions)
            .WithOne(ex => ex.Departments)
            .HasForeignKey(e => e.DepartmentId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Divisions>()
            .HasMany(e => e.Positions)
            .WithOne(ex => ex.Divisions)
            .HasForeignKey(e => e.DivisionId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Levels>()
            .HasMany(e => e.Steps)
            .WithOne(ex => ex.Levels)
            .HasForeignKey(e => e.LevelId)
              .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Steps>()
            .Property(p => p.Salary)
            .HasColumnType("decimal(18,8)");




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


        public DbSet<NumOfRun> NumOfRun { get; set; }
        public DbSet<NumRunDel> NumRunDels { get; set; }
        public DbSet<UserOfNum> UserOfNums { get; set; }

        public DbSet<SchClass> schClasses { get; set; }
        public DbSet<USERINFO> userInformation { get; set; }
        public DbSet<CheckInOut> CheckInOuts { get; set; }
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

        public DbSet<OutSources> OutSources { get; set; }

    }



}
