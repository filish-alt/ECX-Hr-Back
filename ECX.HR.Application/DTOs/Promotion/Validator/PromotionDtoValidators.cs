using ECX.HR.Application.DTOs.Promotion;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Promotions.Validator
{
    public class PromotionDtoValidators : AbstractValidator<PromotionDto>
    {
        public PromotionDtoValidators()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
          
            
        }
    }
}
