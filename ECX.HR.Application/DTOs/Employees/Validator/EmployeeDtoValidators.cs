using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Employees.Validator
{
    public class EmployeeDtoValidators : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidators()
        {
            RuleFor(p => p.FirstName)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            
        }
    }
}
