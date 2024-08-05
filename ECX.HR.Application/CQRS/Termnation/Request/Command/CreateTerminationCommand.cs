

using ECX.HR.Application.DTOs.Termination;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Termination.Request.Command
{
    public class CreateTerminationCommand : IRequest<BaseCommandResponse>
    {
        public TerminationDto TerminationDto { get; set; }
    }
}
