using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Department.Validators
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
        }
    }
}
