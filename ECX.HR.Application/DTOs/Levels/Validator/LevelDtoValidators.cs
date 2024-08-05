using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Levels.Validator
{
    public class LevelDtoValidators : AbstractValidator<LevelDto>
    {
        public LevelDtoValidators()
        {
            RuleFor(p => p.LevelId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            
        }
    }
}
