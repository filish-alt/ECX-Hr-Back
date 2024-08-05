using ECX.HR.Application.DTOs.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Command
{
    public class UpdateLeaveRequestByHrRequestCommand : IRequest<Unit>
    {
        public LeaveRequestDto leaveRequestDto { get; set; }
    }
}
