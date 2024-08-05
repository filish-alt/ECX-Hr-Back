using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Command
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public LeaveRequestDto LeaveRequestDto { get; set; }
    }
}
