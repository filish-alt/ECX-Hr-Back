using ECX.HR.Application.DTOs.Positions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Position.Request.Command
{
    public class UpdatePositionCommand :IRequest<Unit>
    {
        public PositionDto PositionDto { get; set; }
    }
}
