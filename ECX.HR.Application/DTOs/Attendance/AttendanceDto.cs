using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance
{
    public class AttendanceDto : BaseDtos
    {


        public int PId { get; set; }
        public int? AttendanceId { get; set; }
        public Guid Id { get; set; }

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
        public DateTime?Late { get; set; }
        public DateTime?Early { get; set; }
        public int? Status { get; set; }
        public string? AttendanceStatus { get; set; }
        public DateTime? TotalLE { get; set; }

        public double? AbsentDays { get; set; }
        public string? LeaveType { get; set; }
    }
}
