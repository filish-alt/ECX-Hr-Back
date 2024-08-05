using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Request.Command
{
    public class DeleteStepCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
