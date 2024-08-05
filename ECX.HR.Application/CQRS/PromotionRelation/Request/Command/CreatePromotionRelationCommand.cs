
using ECX.HR.Application.DTOs.PromotionRelation;


using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Request.Command
{
    public class CreatePromotionRelationCommand : IRequest<BaseCommandResponse>
    {
        public PromotionRelationDto PromotionRelationDto { get; set; }
    }
}
