
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Supervisors.Validator
{
    public class SupervisorDtoValidator : AbstractValidator<SupervisorDto>  
    {
        public SupervisorDtoValidator()
        {
            RuleFor(p => p.SupervisorLevel)
                  .NotEmpty().WithMessage("{PropertyName} is requiered.")
                  .NotNull();
         
        }
    }
}
