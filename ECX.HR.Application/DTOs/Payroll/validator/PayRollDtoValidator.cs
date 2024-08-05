using ECX.HR.Application.DTOs.LeaveBalance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Payroll.validator
{
    public class PayRollDtoValidator: AbstractValidator<PayRollDto>
    {
        public PayRollDtoValidator() { }
    }
}
