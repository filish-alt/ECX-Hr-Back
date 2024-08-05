using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Command
{
    public class DeleteLeaveRequestCommand :IRequest
    {
        public Guid leaveRequestId { get; set; }    
    }
}
