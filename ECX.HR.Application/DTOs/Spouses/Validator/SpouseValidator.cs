using ECX.HR.Application.DTOs.Spouses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Spouses.Validator
{
    public class SpouseValidator : AbstractValidator<SpouseDto>
    {
        public SpouseValidator()
        {

            //RuleFor(p => p.Name)
            //        .NotEmpty().WithMessage("{PropertyName} is requiered.")
            //        .NotNull();
        
        }
    }
}
