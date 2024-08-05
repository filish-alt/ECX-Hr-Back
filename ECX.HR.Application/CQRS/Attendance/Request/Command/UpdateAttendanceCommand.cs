using ECX.HR.Application.DTOs.Attendance;
using ECX.HR.Application.DTOs.Levels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Request.Command
{
    public class UpdateAttendanceCommand :IRequest<Unit>
    {
        public AttendanceDto AttendanceDto { get; set; }
    }
}
