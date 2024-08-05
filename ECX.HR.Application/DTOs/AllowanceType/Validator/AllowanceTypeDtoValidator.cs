using ECX.HR.Application.DTOs.Allowances.cs;
using ECX.HR.Application.DTOs.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.AllowanceType.Validator
{
    public class AllowanceTypeDtoValidator : AbstractValidator<AllowanceTypeDto>
    {
        public AllowanceTypeDtoValidator() { }  
    }
}
