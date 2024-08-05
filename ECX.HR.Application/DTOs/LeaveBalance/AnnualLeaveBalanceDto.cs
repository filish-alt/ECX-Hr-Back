using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.LeaveBalance
{
    public class AnnualLeaveBalanceDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
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
}
    }
