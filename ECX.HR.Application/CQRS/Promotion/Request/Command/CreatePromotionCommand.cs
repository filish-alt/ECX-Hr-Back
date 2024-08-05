using ECX.HR.Application.DTOs.Promotion;
using ECX.HR.Application.DTOs.Promotions;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Promotion.Request.Command
{
    public class CreatePromotionCommand : IRequest<BaseCommandResponse>
    {
        public PromotionDto PromotionDto { get; set; }
    }
}
