using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Request.Command
{
    public class CreatePayrollCommand : IRequest<BaseCommandResponse>
    {
        public PayRollDto PayRollDto { get; set; }

        public CreatePayrollCommand(PayRollDto PayRollDto)
        {
            PayRollDto = PayRollDto;
        }
        public CreatePayrollCommand()
        {
            // Empty constructor
        }

    }
}
