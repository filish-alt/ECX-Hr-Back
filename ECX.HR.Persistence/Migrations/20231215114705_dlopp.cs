using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECX.HR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dlopp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(6433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 633, DateTimeKind.Utc).AddTicks(849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(6120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 633, DateTimeKind.Utc).AddTicks(478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(5742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 633, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(5432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Terminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(5110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Terminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(4740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(8878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Taxs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(3879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Taxs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(3617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(8269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Supervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(3250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Supervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(2987),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(7651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Step",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(2658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Step",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(2280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(6936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Spouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Spouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1598),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "SalaryType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(5825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SalaryType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(5543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PromotionVacancys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(18),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PromotionVacancys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(9756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(647),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PromotionRelations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(9443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(3638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PromotionRelations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(9076),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payrolls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(8128),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Payrolls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(7861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OverTimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(7527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OverTimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(7262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OtherLeaveBalance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(6918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OtherLeaveBalance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(6473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrganizationalProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(5995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrganizationalProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(5505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "MedicalFunds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(5237),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MedicalFunds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(8179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "MedicalBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(4490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MedicalBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Level",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Level",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "LeaveType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LeaveType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(8763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(8387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Holidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Holidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(1695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmployeePosition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeePosition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(9769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(1435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(1160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmploeeStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmploeeStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmergencyContact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(9426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmergencyContact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(9044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(8715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(8391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(1478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EduactionLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(8026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(1199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EduactionLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(7738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Division",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(7417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Division",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(7042),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DepositAutorizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(6769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DepositAutorizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(6451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(9539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(6181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DeductionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DeductionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(4742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(7748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Deductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Deductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(4468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(4083),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(7145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Banks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(3802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Banks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(3460),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(6539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(3095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(2824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(5901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AssignSupervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(2541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AssignSupervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(2207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AnnualLeaveBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(1868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(4915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AnnualLeaveBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(1395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AllowanceTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(371),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AllowanceTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Allowance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(1001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Allowance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(718),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Adress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(9824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(9458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ActingAssiment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(9105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActingAssiment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(8681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(1929));

            migrationBuilder.CreateTable(
                name: "TempPayrolls",
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
                    HardShipA = table.Column<double>(type: "float", nullable: false),
                    TelephoneA = table.Column<double>(type: "float", nullable: false),
                    TransportA = table.Column<double>(type: "float", nullable: false),
                    TaxExcemptedTA = table.Column<double>(type: "float", nullable: false),
                    HousingA = table.Column<double>(type: "float", nullable: false),
                    LivingA = table.Column<double>(type: "float", nullable: false),
                    OtherTaxA = table.Column<double>(type: "float", nullable: false),
                    OverTime = table.Column<double>(type: "float", nullable: false),
                    OTDay = table.Column<double>(type: "float", nullable: false),
                    OTNight = table.Column<double>(type: "float", nullable: false),
                    OTWeekend = table.Column<double>(type: "float", nullable: false),
                    OTHoliday = table.Column<double>(type: "float", nullable: false),
                    SalaryAdvance = table.Column<double>(type: "float", nullable: false),
                    GrossEarnings = table.Column<double>(type: "float", nullable: false),
                    TaxableAmount = table.Column<double>(type: "float", nullable: false),
                    IncomeTax = table.Column<double>(type: "float", nullable: false),
                    PensionContribution7 = table.Column<double>(type: "float", nullable: false),
                    PensionContribution11 = table.Column<double>(type: "float", nullable: false),
                    CourtAndOtherD = table.Column<double>(type: "float", nullable: false),
                    CreditAssociationD = table.Column<double>(type: "float", nullable: false),
                    RegistrationD = table.Column<double>(type: "float", nullable: false),
                    ShareD = table.Column<double>(type: "float", nullable: false),
                    SavingForCreditAssD = table.Column<double>(type: "float", nullable: false),
                    SavingForHousingD = table.Column<double>(type: "float", nullable: false),
                    LoanRefund = table.Column<double>(type: "float", nullable: false),
                    Penality = table.Column<double>(type: "float", nullable: false),
                    CostShareD = table.Column<double>(type: "float", nullable: false),
                    ForStreetChildrenD = table.Column<double>(type: "float", nullable: false),
                    GebetaLehagerD = table.Column<double>(type: "float", nullable: false),
                    TotalDeduction = table.Column<double>(type: "float", nullable: false),
                    NetPay = table.Column<double>(type: "float", nullable: false),
                    AmtTransfer = table.Column<double>(type: "float", nullable: false),
                    PromotionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousNet = table.Column<double>(type: "float", nullable: false),
                    PayRollStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayRollEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(4149)),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(4473))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempPayrolls", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempPayrolls");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 633, DateTimeKind.Utc).AddTicks(849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 633, DateTimeKind.Utc).AddTicks(478),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 633, DateTimeKind.Utc).AddTicks(17),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(9657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(5432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Terminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(9234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Terminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(8878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Taxs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(8593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(3879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Taxs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(8269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Supervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(7989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(3250));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Supervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(7651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(2987));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Step",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(7297),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Step",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(6936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Spouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(6522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Spouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(6167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "SalaryType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(5825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SalaryType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(5543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PromotionVacancys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(18));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PromotionVacancys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(4164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(647));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(4762),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 945, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PromotionRelations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(3638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(9443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PromotionRelations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(2620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payrolls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(1538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(8128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Payrolls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(1201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(7861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OverTimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OverTimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(576),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OtherLeaveBalance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(6918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OtherLeaveBalance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(9802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrganizationalProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(9306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrganizationalProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(8795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "MedicalFunds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(8517),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(5237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MedicalFunds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(8179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "MedicalBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(7722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MedicalBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(7219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Level",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(6879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Level",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(6613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "LeaveType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(6331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LeaveType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(2164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 632, DateTimeKind.Utc).AddTicks(1814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(8387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Holidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(5065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Holidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(4804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(1695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmployeePosition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeePosition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3033),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(4197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(1160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmploeeStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmploeeStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(3594),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 944, DateTimeKind.Utc).AddTicks(438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EmergencyContact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(2593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(9426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmergencyContact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(2248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(1885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(8715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(1478),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "EduactionLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(1199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EduactionLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Division",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Division",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 631, DateTimeKind.Utc).AddTicks(142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DepositAutorizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(9813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DepositAutorizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(9539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(6451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8892),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DeductionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DeductionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(7748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Deductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Deductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(8287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(5331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(7414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(7145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Banks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(6858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Banks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(6539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(3460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(6262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(5901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(2824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AssignSupervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(5615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AssignSupervisor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(5333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AnnualLeaveBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(4915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AnnualLeaveBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(4542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(1395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AllowanceTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AllowanceTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Allowance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(4261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Allowance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 943, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Adress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(3040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(9824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(2712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ActingAssiment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(2311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActingAssiment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 14, 12, 29, 46, 630, DateTimeKind.Utc).AddTicks(1929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 11, 47, 3, 942, DateTimeKind.Utc).AddTicks(8681));
        }
    }
}
