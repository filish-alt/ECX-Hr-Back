using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.EducationLevels.Validators
{
    public class EducationLevelDtoValidator :AbstractValidator<EducationLevelDto>
    {
        public EducationLevelDtoValidator()
        {
            RuleFor(p => p.EducationName)
                    .NotEmpty().WithMessage("{PropertyName} is requiered.")
                    .NotNull();
        }
    }
}
