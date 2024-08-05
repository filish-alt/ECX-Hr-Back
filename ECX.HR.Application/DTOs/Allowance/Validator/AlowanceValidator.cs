using ECX.HR.Application.DTOs.Allowances.cs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Allowances.Validator
{
    public class AlowanceValidator : AbstractValidator<AllowanceDto>
    {
        public AlowanceValidator()
        {
            RuleFor(p => p.AllowanceType)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
            RuleFor(p => p.Position)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
            RuleFor(p => p.Step)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
         
        }

    }
}
