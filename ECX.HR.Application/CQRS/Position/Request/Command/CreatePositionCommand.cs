using ECX.HR.Application.DTOs.Positions;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Position.Request.Command
{
    public class CreatePositionCommand : IRequest<BaseCommandResponse>
    {
        public PositionDto PositionDto { get; set; }
    }
}
