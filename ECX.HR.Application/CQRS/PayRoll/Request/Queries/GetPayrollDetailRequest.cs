using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Request.Queries
{
    public class GetPayrollDetailRequest : IRequest<PayRollDto>
    {
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public int status { get; set; }
    }
}
