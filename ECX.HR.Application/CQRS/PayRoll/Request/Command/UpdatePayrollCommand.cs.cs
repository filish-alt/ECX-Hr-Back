using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Request.Command
{
    public class UpdatePayrollCommand: IRequest<Unit>
    {
        public PayRollDto PayRollDto { get; set; }
    }
}
