using ECX.HR.Application.DTOs.MedicalFunds;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.MedicalFunds.Validator
{
    public class MedicalFundDtoValidators : AbstractValidator<MedicalFundDto>
    {
        public MedicalFundDtoValidators()
        {
            RuleFor(p => p.MedicalRequestId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.InstitutionName)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();

        }
    }
}
