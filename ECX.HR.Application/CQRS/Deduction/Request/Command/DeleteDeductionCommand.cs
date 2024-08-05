using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Request.Command
{
    public class DeleteDeductionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
