using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Trainings.Validator
{
    public class TrainingDtoValidator : AbstractValidator<TrainingDto>  
    {
        public TrainingDtoValidator()
        {
 /*           RuleFor(p => p.TypeOfTraining)
                  .NotEmpty().WithMessage("{PropertyName} is requiered.")
                  .NotNull();
                
            RuleFor(P => P.From).NotEmpty();
            RuleFor(P => P.To).NotEmpty();
            RuleFor(P => P).Must(P => P.To == default(DateTime) || P.From == default(DateTime) || P.To > P.From)
            .WithMessage("EndTime must greater than StartTime");*/
        }
    }
}
