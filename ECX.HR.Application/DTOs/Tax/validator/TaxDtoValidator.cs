using ECX.HR.Application.DTOs.Allowances.cs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Tax.validator
{
    public class TaxDtoValidator : AbstractValidator<TaxDto>
    {
        public TaxDtoValidator() { }
    }
}
