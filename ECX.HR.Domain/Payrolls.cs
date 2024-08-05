using ECX.HR.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class Payrolls : BaseDomainEntity
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

        public double HardShipA { get; set; }
        public double TelephoneA { get; set; }
        public double TransportA { get; set; }
        public double TaxExcemptedTA { get; set; }
        public double HousingA { get; set; }
        public double LivingA { get; set; }
        public double OtherTaxA { get; set; }

        public double OverTime { get; set; }
        public double OTDay { get; set; }
        public double OTNight { get; set; }
        public double OTWeekend { get; set; }
        public double OTHoliday { get; set; }

        public double SalaryAdvance { get; set; }
        public double GrossEarnings { get; set; }
        public double TaxableAmount { get; set; }
        public double IncomeTax { get; set; }

        public double PensionContribution7 { get; set; }
        public double PensionContribution11 { get; set; }
        public double CourtAndOtherD { get; set; }
        public double CreditAssociationD { get; set; }
        public double RegistrationD { get; set; }
        public double ShareD { get; set; }
        public double SavingForCreditAssD { get; set; }
        public double SavingForHousingD { get; set; }
        public double LoanRefund { get; set; }
        public double Penality { get; set; }
        public double CostShareD { get; set; }
       public double ForStreetChildrenD { get; set; }
        public double GebetaLehagerD { get; set; }
        public double   AbsentD { get; set; }
        public double AbsentTolerance { get; set; }
        public double TotalDeduction { get; set; }
        public double NetPay { get; set; }
        public double AmtTransfer { get; set; }
        public string PromotionStatus { get; set; }
        public string ActingStatus { get; set; }
        public double PreviousNet { get; set; }
        public DateTime PayRollStartDate { get; set; }
        public DateTime PayRollEndDate { get; set; }

        public int Status { get; set; }
    }
   
}
