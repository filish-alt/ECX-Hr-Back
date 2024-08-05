using ECX.HR.Application.DTOs.OrganizationalProfiles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.OrganizationalProfile.Validator
{
    public class OrganizationalProfileDtoValidator : AbstractValidator<OrganizationalProfileDto>
    {
        public OrganizationalProfileDtoValidator()
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
