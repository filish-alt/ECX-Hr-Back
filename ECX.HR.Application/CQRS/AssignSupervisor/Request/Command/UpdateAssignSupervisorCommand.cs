
using ECX.HR.Application.DTOs.AssignSupervisor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisor.Request.Command
{
    public class UpdateAssignSupervisorCommand :IRequest<Unit>
    {
        public AssignSupervisorDto AssignSupervisorDto { get; set; }
    }
}
