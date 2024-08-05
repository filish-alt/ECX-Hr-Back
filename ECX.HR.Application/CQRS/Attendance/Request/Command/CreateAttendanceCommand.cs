using ECX.HR.Application.CQRS.Attendance;
using ECX.HR.Application.DTOs.Levels;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Request.Command
{
    public class CreateAttendanceCommand : IRequest<BaseCommandResponse>
    {
        public AttendanceDto AttendanceDto { get; set; }
    }


}
