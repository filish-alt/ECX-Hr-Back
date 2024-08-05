
using ECX.HR.Application.DTOs.Termination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Termination.Request.Queries
{
    public class GetTerminationDetailRequest :IRequest<List<TerminationDto>>
    {
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
      
    }
}
