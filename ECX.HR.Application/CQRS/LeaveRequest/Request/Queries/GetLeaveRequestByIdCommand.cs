using ECX.HR.Application.DTOs.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestByIdCommand : IRequest<List<LeaveRequestDto>>
    {
        public Guid EmpId { get; set; }    
    }
}
