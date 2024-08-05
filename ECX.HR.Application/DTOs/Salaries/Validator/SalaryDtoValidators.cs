using ECX.HR.Application.DTOs.Salaries;
using FluentValidation;


namespace ECX.HR.Application.DTOs.Salary.Validator
{
    public class SalaryDtoValidators : AbstractValidator<SalaryTypeDto>
    {
        public SalaryDtoValidators()
        {
            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            
            
        }
    }
}
