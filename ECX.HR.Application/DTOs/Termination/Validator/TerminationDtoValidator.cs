
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Termination.Validator
{
    public class TerminationDtoValidator : AbstractValidator<TerminationDto>
    {
        public TerminationDtoValidator()
        {

            //RuleFor(p => p.Name)
            //        .NotEmpty().WithMessage("{PropertyName} is requiered.")
            //        .NotNull();
        
        }
    }
}
