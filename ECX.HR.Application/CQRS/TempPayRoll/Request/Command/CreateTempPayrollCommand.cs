using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Application.DTOs.TempPayroll;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Request.Command
{
    public class CreateTempPayrollCommand : IRequest<BaseCommandResponse>
    {
        public TempPayRollDto TempPayRollDto { get; set; }

        public CreateTempPayrollCommand(TempPayRollDto PayRollDto)
        {
            PayRollDto = PayRollDto;
        }
        public CreateTempPayrollCommand()
        {
            // Empty constructor
        }

    }
}
