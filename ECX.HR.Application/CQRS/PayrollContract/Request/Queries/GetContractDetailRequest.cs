
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayrollContract.Request.Queries
{
    public class GetContractDetailRequest : IRequest<PayrollContractDto>
    {
        public Guid Id { get; set; }
    }

}