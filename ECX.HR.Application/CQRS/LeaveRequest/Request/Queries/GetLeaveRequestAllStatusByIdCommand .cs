using ECX.HR.Application.DTOs.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestAllStatusCommand : IRequest<List<LeaveRequestDto>>
    {

        public string LeaveStatus { get; set; }
     
    }
}
