using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Request.Command
{
    public class DeleteTempPayrollCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
