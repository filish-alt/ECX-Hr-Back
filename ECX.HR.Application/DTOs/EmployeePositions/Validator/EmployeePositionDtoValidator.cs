using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.EmployeePositions.Validator
{
    public class EmployeePositionDtoValidator :AbstractValidator<EmployeePositionDto>   
    {
        public EmployeePositionDtoValidator()
        {
           /* RuleFor(p => p.position)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.DivisionId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.BranchId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
                     
            RuleFor(P => P.StartDate).NotEmpty();
            RuleFor(P => P.EndDate).NotEmpty();
            RuleFor(P => P).Must(P => P.EndDate == default(DateTime) || P.StartDate == default(DateTime) || P.EndDate > P.StartDate)
            .WithMessage("EndTime must greater than StartTime");*/
        }
    }
}
