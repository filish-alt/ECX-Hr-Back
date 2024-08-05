using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Branchs.Validator
{
    public class BranchValidator : AbstractValidator<BranchDto>
    {
        public BranchValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty().WithMessage("{PropertyName} is requiered.")
                .NotNull();
           
               

        }
    }
}
