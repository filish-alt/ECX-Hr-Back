
using ECX.HR.Application.DTOs.Addresss;
using ECX.HR.Application.DTOs.AssignSupervisor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisor.Request.Queries
{
    public class GetAssignSupervisorDetailRequest :IRequest<AssignSupervisorDto>
    {
      public Guid Id { get; set; }
        public Guid PositionId { get; set; }
        public int status { get; set; }
    }
}
