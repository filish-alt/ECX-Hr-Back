
using ECX.HR.Application.DTOs.Supervisors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Supervisor.Request.Queries
{
    public class GetSupervisorDetailRequest :IRequest<SupervisorDto>
    {
        public Guid Id { get; set; }
    }
}
