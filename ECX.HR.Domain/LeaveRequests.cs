using ECX.HR.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class LeaveRequests : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
    
        public Guid leaveRequestId { get; set; }
    

        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }

        [ForeignKey("LeaveType")]
        public Guid leaveTypeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public string ApprovedBy { get; set; }
        public string LeaveStatus { get; set; }

        public string Reason { get; set; }
        public string Supervisor { get; set; }

        public string? File 
        { get; set; }
      //  public byte[] FileData { get; set; }
        public Decimal WorkingDays { get; set; }

        public int Status { get; set; }
        public DateTime SickStartDate { get; set; }
        public DateTime SickEndDate { get; set; }
        public Guid departmentId { get; set; }

        public Guid employeePositionId { get; set; }

    }
}
