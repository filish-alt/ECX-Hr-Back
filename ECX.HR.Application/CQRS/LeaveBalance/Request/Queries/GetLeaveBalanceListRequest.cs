
using ECX.HR.Application.DTOs.LeaveBalance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveBalance.Request.Queries
{
    public class GetLeaveBalanceListRequest :IRequest<List<AnnualLeaveBalanceDto>>
    {
       
    }
}
