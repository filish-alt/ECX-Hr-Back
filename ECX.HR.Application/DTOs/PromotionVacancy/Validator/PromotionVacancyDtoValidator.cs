
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.PromotionVacancy.Validator
{
    public class PromotionVacancyDtoValidator : AbstractValidator<PromotionVacancyDto>
    {
        public PromotionVacancyDtoValidator()
        {
           /* RuleFor(p => p.PositionId)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();*/
            
        }
    }
}
