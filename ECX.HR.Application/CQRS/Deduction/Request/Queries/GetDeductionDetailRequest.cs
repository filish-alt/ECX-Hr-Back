using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.DTOs.DeductionType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Request.Queries
{
    public class GetDeductionDetailRequest : IRequest<DeductionDto>
    {
        public Guid Id { get; set; }
    }
}
