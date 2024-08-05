using ECX.HR.Application.DTOs.Levels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Request.Queries
{
    public class GetAttendanceDetailRequest :IRequest<AttendanceDto>
    {
        public Guid  Id { get; set; }
    }
}
