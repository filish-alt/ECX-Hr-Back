using ECX.HR.Application.DTOs.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.DeductionType.Validator
{
    public class DeductionTypeDtoValidator : AbstractValidator<DeductionTypeDto>
    {
        public DeductionTypeDtoValidator() { }
    }
}
