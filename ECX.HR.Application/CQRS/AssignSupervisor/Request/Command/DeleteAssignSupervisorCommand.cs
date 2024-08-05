using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisor.Request.Command
{
    public class DeleteAssignSupervisorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
