using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Level.Request.Command
{
    public class DeleteLevelCommand : IRequest
    {
        public Guid LevelId { get; set; }
    }
}
