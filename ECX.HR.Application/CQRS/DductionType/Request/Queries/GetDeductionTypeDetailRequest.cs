using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.DeductionType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DductionType.Request.Queries
{
    public class GetDeductionTypeDetailRequest : IRequest<DeductionTypeDto>
    {
        public Guid Id { get; set; }
    }
}
