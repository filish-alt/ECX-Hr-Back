using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.MedicalBalance.Validator
{
    public class MedicalBalanceDtoValidators : AbstractValidator<MedicalBalanceDto>
    {
        public MedicalBalanceDtoValidators()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.EmpId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            
        }
    }
}
