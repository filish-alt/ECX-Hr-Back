using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveType.Request.Command
{
    public class DeleteLeaveTypeCommand : IRequest
    {
        public Guid leaveTypeId { get; set; }
    }
}
