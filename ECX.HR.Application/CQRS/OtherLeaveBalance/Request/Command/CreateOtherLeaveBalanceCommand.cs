
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command
{
    public class CreateOtherLeaveBalanceCommand : IRequest<BaseCommandResponse>
    {
        public OtherLeaveBalanceDto OtherLeaveBalanceDto { get; set; }

        public CreateOtherLeaveBalanceCommand(OtherLeaveBalanceDto otherLeaveBalanceDto)
    {
           OtherLeaveBalanceDto = otherLeaveBalanceDto;
        }
        public CreateOtherLeaveBalanceCommand()
        {
            // Empty constructor
        }

    }
}
