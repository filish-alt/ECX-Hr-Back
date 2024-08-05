
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayrollContract.Request
{
    public class GetContractListRequest : IRequest<List<PayrollContractDto>>
    {

    }
   
}
