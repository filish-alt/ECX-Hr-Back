using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.DeductionType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DductionType.Request.Command
{
    public class UpdateDeductionTypeCommand : IRequest<Unit>
    {
        public DeductionTypeDto DeductionTypeDto{get;set;}
    }
}
