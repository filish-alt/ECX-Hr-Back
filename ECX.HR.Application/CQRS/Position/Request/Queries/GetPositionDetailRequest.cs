
using ECX.HR.Application.DTOs.Positions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Position.Request.Queries
{
    public class GetPositionDetailRequest :IRequest<PositionDto>
    {
        public Guid PositionId { get; set; }
    }
}
