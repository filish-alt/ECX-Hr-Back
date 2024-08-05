
using ECX.HR.Application.DTOs.Allowances.cs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowance.Request.Queries
{
    public class GetAllowanceListRequest :IRequest<List<AllowanceDto>>
    {
       
    }
}
