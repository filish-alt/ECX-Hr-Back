using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.OverTime;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Request.Queries
{
    public class GetDetailOverTimeRequest : IRequest<OverTimeDto>
    {
        public Guid Empid { get; set; }
        
    }
}
