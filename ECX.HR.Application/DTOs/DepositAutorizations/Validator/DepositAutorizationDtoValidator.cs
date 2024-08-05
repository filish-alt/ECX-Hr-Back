using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.DepositAutorizations.Validator
{
    public class DepositAutorizationDtoValidator : AbstractValidator<DepositAutorizationDto>
    {
        public DepositAutorizationDtoValidator()
        {
            RuleFor(p => p.BankId)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
            RuleFor(p => p.TinNumber)
                .NotEmpty().WithMessage("{PropertyName} is requiered.");
                //.Must(IsTinNumberValid).WithMessage("Please specify a valid Tinnumber");
        }
        //public static bool IsTinNumberValid(string Tinnumber)
        //{
        //    string regex = @"^[0-9]{0,9}$";
        //    if (Tinnumber != null)
        //        return Regex.IsMatch(Tinnumber, regex);
        //    else return false;
        //}
    }
}
