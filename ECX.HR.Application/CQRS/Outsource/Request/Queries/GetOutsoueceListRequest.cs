using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Outsource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Request.Queries
{
    public class GetOutsoueceListRequest : IRequest<List<OutsourceDto>>
    {

    }
}
