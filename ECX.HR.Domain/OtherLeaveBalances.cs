using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ECX.HR.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ECX.HR.Domain
{
    public class OtherLeaveBalances :BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        
        [Key]
      
        public Guid Id { get; set; }
        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
      
   
        public Decimal SickDefaultBalance { get; set; }
        public Decimal SickRemainingBalance { get; set; }
        public Decimal MaternityDefaultBalance { get; set; }
        public Decimal MaternityRemainingBalance { get; set; }
        public Decimal PaternityDefaultBalance { get; set; }
        public Decimal PaternityRemainingBalance { get; set; }
        public Decimal CompassinateDefaultBalance { get; set; }
        public Decimal CompassinateRemainingBalance { get; set; }
        public Decimal EducationDefaultBalance { get; set; }
        public Decimal EducationRemainingBalance { get; set; }
        public Decimal MarriageDefaultBalance { get; set; }
        public Decimal MarriageRemainingBalance { get; set; }
        public Decimal LeaveWotPayDefaultBalance { get; set; }
        public Decimal LeaveWotPayRemainingBalance { get; set; }
        public Decimal CourtLeaveDefaultBalance { get; set; }
        public Decimal CourtLeaveRemainingBalance { get; set; }
        public Decimal AbortionLeaveDefaultBalance { get; set; }
        public Decimal AbortionLeaveRemainingBalance { get; set; }
      
        public Decimal OtherLeaveRemainingBalance { get; set; }

        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }
        public DateTime SickEndDate { get; set; }
        public DateTime SickStartDate { get; set; }
        public int IsExpired { get; set; }   
        public int Status { get; set; }
        public virtual Employees Employees { get; set; }
        public int UnusedDays { get; set; }
        public AnnualLeaveBalances AnnualLeaveBalance { get; set; }// Navigation property

    }
}
