using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECX.HR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class contract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.CreateTable(
                name: "ContractEmployees",
                columns: table => new
                {
                    EmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EcxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBitrh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBith = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MartialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PensionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crime = table.Column<bool>(type: "bit", nullable: false),
                    CrimeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    position = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<long>(type: "bigint", nullable: false),
                    TinNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 2, 6, 49, 30, 220, DateTimeKind.Utc).AddTicks(5888)),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 2, 6, 49, 30, 220, DateTimeKind.Utc).AddTicks(6188))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEmployees", x => x.EmpId);
                });


            migrationBuilder.CreateTable(
                name: "PayrollContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EcxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfEmployeement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GradeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StepID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    Bank = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    TinNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryAdvance = table.Column<double>(type: "float", nullable: false),
                    GrossEarnings = table.Column<double>(type: "float", nullable: false),
                    TaxableAmount = table.Column<double>(type: "float", nullable: false),
                    IncomeTax = table.Column<double>(type: "float", nullable: false),
                    PensionContribution7 = table.Column<double>(type: "float", nullable: false),
                    PensionContribution11 = table.Column<double>(type: "float", nullable: false),
                    ContratStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 2, 6, 49, 30, 227, DateTimeKind.Utc).AddTicks(8501)),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 2, 6, 49, 30, 227, DateTimeKind.Utc).AddTicks(8927))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollContracts", x => x.Id);
                });

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractEmployees");

          
            migrationBuilder.DropTable(
                name: "PayrollContracts");

           

        }
    }
}
