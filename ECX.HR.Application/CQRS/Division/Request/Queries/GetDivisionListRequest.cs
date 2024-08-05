using ECX.HR.Application.DTOs.Division;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Division.Request.Queries
{
    public class GetDivisionListRequest :IRequest<List<DivisionDto>>
    {
       
    }
}
