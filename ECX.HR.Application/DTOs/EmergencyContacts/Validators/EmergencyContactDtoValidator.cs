using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.EmergencyContacts.Validators
{
    public class EmergencyContactDtoValidator : AbstractValidator<EmergencyContactDto>    

    {
        public EmergencyContactDtoValidator()
        {

            RuleFor(p => p.Region)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
            RuleFor(p => p.Town)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
            RuleFor(p => p.Relationship)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.PhoneNumber)
                .Must(IsPhoneValid).WithMessage("Please specify a valid PhoneNumber");
            
        }
        public static bool IsPhoneValid(string PhoneNumber)
        {
            string regex = @"^([\+]?251[-]?|[0])?[1-9][0-9]{8}$";
            if (PhoneNumber != null)
                return Regex.IsMatch(PhoneNumber, regex);
            else return false;
        }

    }
}
