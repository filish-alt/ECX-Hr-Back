using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Request.Command
{
    public class DeleteAttendanceCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
