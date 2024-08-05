using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.DeductionType;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DductionType.Request.Command
{
    public class CreateDeductionTypeCommand : IRequest<BaseCommandResponse>
    {
        public DeductionTypeDto deductionTypeDto { get; set; }
    }
}
