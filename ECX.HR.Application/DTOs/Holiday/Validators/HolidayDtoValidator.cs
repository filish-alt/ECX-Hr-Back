
using ECX.HR.Application.DTOs.Holiday;
using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ECX.HR.Application.DTOs.Holiday.Validators
{
    public class HolidayDtoValidator : AbstractValidator<HolidayDto>
    {
        public HolidayDtoValidator() {
            RuleFor(p => p.Description)
                .NotNull()
               .NotEmpty().WithMessage("(propertyname) is required")
               .MaximumLength(50).WithMessage("(propertyname) length must be less than 50");
   } }
    }

