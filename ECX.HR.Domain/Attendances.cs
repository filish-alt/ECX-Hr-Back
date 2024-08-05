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
    public class Attendances : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
        public int PId { get; set; }
        [Key]
     
        public Guid Id { get; set; }

        public int? AttendanceId { get; set; }
        [ForeignKey("Employees")]
        public Guid? EmpId { get; set; }

        public DateTime? date { get; set; }
        public string? TimeTable { get; set; }

        public DateTime? OnDuty { get; set; }

        public DateTime? OffDuty { get; set; }

        public DateTime? ClockIn { get; set; }

        public DateTime? ClockOut { get; set; }

        public string? Department { get; set; }
        public Decimal? Normall { get; set; }
        public Decimal? RealTime { get; set; }
        public DateTime? Late { get; set; }
        public DateTime? Early { get; set; }
        public int? Status { get; set; }
        public string? AttendanceStatus { get; set; }
        public double? AbsentDays { get; set; }
        public DateTime? TotalLE { get; set; }

        public string? LeaveType { get; set; }

    }
}
