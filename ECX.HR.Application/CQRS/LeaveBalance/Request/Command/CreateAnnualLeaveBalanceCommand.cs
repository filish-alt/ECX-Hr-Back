
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveBalance.Request.Command
{
    public class CreateAnnualLeaveBalanceCommand : IRequest<BaseCommandResponse>
    {
        public AnnualLeaveBalanceDto LeaveBalanceDto { get; set; }

        public CreateAnnualLeaveBalanceCommand(AnnualLeaveBalanceDto leaveBalanceDto)
        {
            LeaveBalanceDto = leaveBalanceDto;
        }
        public CreateAnnualLeaveBalanceCommand()
        {
            // Empty constructor
        }

    }
}
