
using ECX.HR.Application.DTOs.LeaveBalance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveBalance.Request.Queries
{
    public class GetLeaveBalanceDetailRequest :IRequest<List<AnnualLeaveBalanceDto>>
    {
      public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public int status { get; set; }
    }
}
