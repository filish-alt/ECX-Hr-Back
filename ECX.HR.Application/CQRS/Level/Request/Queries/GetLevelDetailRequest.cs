using ECX.HR.Application.DTOs.Levels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Level.Request.Queries
{
    public class GetLevelDetailRequest :IRequest<LevelDto>
    {
        public Guid LevelId { get; set; }
    }
}
