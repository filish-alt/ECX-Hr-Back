using ECX.HR.Application.DTOs.Promotion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Promotion.Request.Command
{
    public class UpdatePromotionCommand :IRequest<Unit>
    {
        public PromotionDto PromotionDto { get; set; }
    }
}
