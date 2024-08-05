

using ECX.HR.Application.DTOs.Termination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Termination.Request.Queries
{
    public class GetTerminationListRequest :IRequest<List<TerminationDto>>
    {
       
    }
}
