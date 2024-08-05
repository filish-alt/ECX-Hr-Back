
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Positions.Validator
{
    public class PositionDtoValidators : AbstractValidator<PositionDto>
    {
        public PositionDtoValidators()
        {
           /* RuleFor(p => p.PositionId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();*/
            
        }
    }
}
