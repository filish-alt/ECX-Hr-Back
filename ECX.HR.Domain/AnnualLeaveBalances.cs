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
    public class AnnualLeaveBalances :BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        
        [Key]
      
        public Guid Id { get; set; }
        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
        public Decimal PreviousTwoYear { get; set; }
        public Decimal PreviousYearAnnualBalance { get; set; }
        public Decimal TotalRemaining { get; set; }
        public Decimal TotalRequest { get; set; }
        public Decimal AnnualDefaultBalance { get; set; }
        public Decimal AnnualRemainingBalance { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }
        public int UnusedDays { get; set; } 
        public int IsExpired { get; set; }   
        public int Status { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
