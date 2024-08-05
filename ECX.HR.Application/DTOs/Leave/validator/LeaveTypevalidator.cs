using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Leave;

namespace ECX.HR.Application.DTOs.LeaveType.validator
{
    public class LeaveTypeeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public LeaveTypeeDtoValidator()
        {
            //RuleFor(p => p.Region)
            //    .NotEmpty().WithMessage("{PropertyName} is requiered.")
            //    .NotNull();
            //RuleFor(p => p.Town)
            //    .NotEmpty().WithMessage("{PropertyName} is requiered.")
            //    .NotNull();
            //RuleFor(p => p.PhoneNumber)
            //    .Must(IsPhoneValid).WithMessage("Please specify a valid PhoneNumber");
            ////RuleFor(p => p.Email)
            //    .Must(IsEmailValid).WithMessage("please specify a valid Email");
        }


        //public static bool IsPhoneValid(string PhoneNumber)
        //{
        //    string regex = @"^([\+]?251[-]?|[0])?[1-9][0-9]{8}$";
        //    if (PhoneNumber != null)
        //        return Regex.IsMatch(PhoneNumber, regex);
        //    else return false;
        //}

        //public static bool IsEmailValid(string Email)
        //{

        //    string regex = @"^[A-Z0-9+_.-]+@[A-Z0-9.-]+$";
        //    if (Email != null)
        //        return Regex.IsMatch(Email, regex);
        //    else return false;
        //}
    }
}

