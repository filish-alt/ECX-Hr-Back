using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Domain.Common;

namespace ECX.HR.Domain
{
    public class PayrollContracts : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid Id { get; set; }


        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
        [ForeignKey("Employees")]
        public string EcxId { get; set; }
        public DateTime DateOfEmployeement { get; set; }

        public Guid PositionID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? GradeID { get; set; }
        public Guid StepID { get; set; }
        public Guid BranchID { get; set; }
        public double BasicSalary { get; set; }


        public Guid Bank { get; set; }
        public string BankBranch { get; set; }
        public long BankAccountNumber { get; set; }
        public string TinNumber { get; set; }
        public double SalaryAdvance { get; set; }
        public double GrossEarnings { get; set; }
        public double TaxableAmount { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        public double PensionContribution7 { get; set; }
        public double PensionContribution11 { get; set; }
        public DateTime ContratStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public DateTime PayRollStartDate { get; set; }
        public DateTime PayRollEndDate { get; set; }

        public int Status { get; set; }
    }
}
