using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.DTOs.DeductionType;
using ECX.HR.Application.DTOs.MedicalBalance;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Request.Command
{
    public class CreateDeductionCommand : IRequest<BaseCommandResponse>
    {
        public DeductionDto deductionDto { get; set; }
        public CreateDeductionCommand(DeductionDto DeductionDto)
        {
            deductionDto = DeductionDto;
        }
        public CreateDeductionCommand()
        {
            // Empty constructor
        }
    }
}
