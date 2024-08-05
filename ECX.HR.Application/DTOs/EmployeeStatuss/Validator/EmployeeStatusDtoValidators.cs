using ECX.HR.Application.DTOs.EmployeeStatuss;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.EmployeeStatus.Validator
{
    public class EmployeeStatusDtoValidators : AbstractValidator<EmployeeStatusDto>
    {
        public EmployeeStatusDtoValidators()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            
        }
    }
}
