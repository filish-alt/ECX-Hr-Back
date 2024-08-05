
using ECX.HR.Application.DTOs.PromotionRelation;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Request.Command
{
    public class UpdatePromotionRelationCommand :IRequest<Unit>
    {
        public PromotionRelationDto PromotionRelationDto { get; set; }
    }
}
