using ECX.HR.Application.DTOs.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Bank.validator
{
    public class BankDtoValidator : AbstractValidator<BankDto>
    {
        public BankDtoValidator() { }
    }
}
