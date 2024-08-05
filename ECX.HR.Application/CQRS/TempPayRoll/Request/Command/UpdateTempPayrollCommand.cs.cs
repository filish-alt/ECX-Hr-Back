using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Application.DTOs.TempPayroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Request.Command
{
    public class UpdateTempPayrollCommand: IRequest<Unit>
    {
        public TempPayRollDto TempPayRollDto { get; set; }
    }
}
