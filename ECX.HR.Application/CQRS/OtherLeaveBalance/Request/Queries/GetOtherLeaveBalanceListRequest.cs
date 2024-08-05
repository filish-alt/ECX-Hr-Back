
using ECX.HR.Application.DTOs.LeaveBalance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Queries
{
    public class GetOtherLeaveBalanceListRequest :IRequest<List<OtherLeaveBalanceDto>>
    {
       
    }
}
