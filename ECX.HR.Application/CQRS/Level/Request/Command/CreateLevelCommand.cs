using ECX.HR.Application.DTOs.Levels;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Level.Request.Command
{
    public class CreateLevelCommand : IRequest<BaseCommandResponse>
    {
        public LevelDto LevelDto { get; set; }
    }
}
