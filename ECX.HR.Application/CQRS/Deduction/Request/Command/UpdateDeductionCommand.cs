using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.DTOs.DeductionType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECX.HR.Application.CQRS.Deduction.Request.Command
{
    public class UpdateDeductionCommand : IRequest<Unit>
    {
        public DeductionDto deductionDto{get; set; }
    }
}
