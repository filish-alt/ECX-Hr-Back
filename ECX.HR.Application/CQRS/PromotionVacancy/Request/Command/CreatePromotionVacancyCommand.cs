
using ECX.HR.Application.DTOs.PromotionVacancy;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Request.Command
{
    public class CreatePromotionVacancyCommand : IRequest<BaseCommandResponse>
    {
        public PromotionVacancyDto PromotionVacancyDto { get; set; }
    }
}
