using ECX.HR.Application.DTOs.Addresss;
using ECX.HR.Application.DTOs.AssignSupervisor;
using ECX.HR.Application.DTOs.Department;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisor.Request.Command
{
    public class CreateAssignSupervisorCommand : IRequest<BaseCommandResponse>
    {
        public AssignSupervisorDto AssignSupervisorDetailDto { get; set; }
    }
}
