using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Position.Request.Command
{
    public class DeletePositionCommand : IRequest
    {
        public Guid PositionId { get; set; }
    }
}
