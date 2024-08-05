
using ECX.HR.Application.DTOs.Promotion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Level.Request.Queries
{
    public class GetPromotionDetailRequest :IRequest<PromotionDto>
    {
        public Guid Id { get; set; }
    }
}
