using ECX.HR.Application.DTOs.LeaveBalance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.TempPayroll.validator
{
    public class TempPayRollDtoValidator: AbstractValidator<TempPayRollDto>
    {
        public TempPayRollDtoValidator() { }
    }
}
