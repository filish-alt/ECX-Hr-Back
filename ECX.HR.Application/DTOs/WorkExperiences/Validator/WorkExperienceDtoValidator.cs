using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.WorkExperiences.Validator
{
    public class WorkExperienceDtoValidator :AbstractValidator<WorkExperienceDto>
    {
        public WorkExperienceDtoValidator()
        {
          /*  RuleFor(p => p.CompanyName)
                 .NotEmpty().WithMessage("{PropertyName} is requiered.")
                 .NotNull();
            RuleFor(p => p.PostionHeld)
                 .NotEmpty().WithMessage("{PropertyName} is requiered.")
                 .NotNull();

            RuleFor(P => P.From).NotEmpty();
            RuleFor(P => P.To).NotEmpty();
            RuleFor(P => P).Must(P => P.To == default(DateTime) || P.From == default(DateTime) || P.To > P.From)
            .WithMessage("EndTime must greater than StartTime");*/
        }
    }
}
