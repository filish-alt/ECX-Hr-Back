using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Education.Validator
{
    public class EducationValidator : AbstractValidator<EducationDto>
    {
        public EducationValidator()
        {/*

            RuleFor(p => p.NameOfInstitute)
                    .NotEmpty().WithMessage("{PropertyName} is requiered.")
                    .NotNull();
            RuleFor(p => p.FieldOfStudy)
                    .NotEmpty().WithMessage("{PropertyName} is requiered.")
                    .NotNull()
                    .Must(IsDateValid).WithMessage("Please specify a valid PhoneNumber");
            RuleFor(P => P.From).NotEmpty();
            RuleFor(P => P.To).NotEmpty();
            RuleFor(P => P).Must(P => P.To == default(DateTime) || P.From == default(DateTime) || P.To > P.From)
            .WithMessage("EndTime must greater than StartTime");
        }
        public static bool IsDateValid(string PhoneNumber)
        {
            string regex = @"^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[1,2])\/(19|20)\d{2}$";
            if (PhoneNumber != null)
                return Regex.IsMatch(PhoneNumber, regex);
            else return false;
        }*/


        }
    }
}
