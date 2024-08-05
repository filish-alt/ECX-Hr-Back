using ECX.HR.Application.DTOs.Promotion;
using ECX.HR.Application.DTOs.Promotions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Promotion.Request.Queries
{
    public class GetPromotionListRequest :IRequest<List<PromotionDto>>
    {
       
    }
}
