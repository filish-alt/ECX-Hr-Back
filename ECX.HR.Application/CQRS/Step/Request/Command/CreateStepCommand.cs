using ECX.HR.Application.DTOs.Step;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Request.Command
{
    public class CreateStepCommand : IRequest<BaseCommandResponse>
    {
        public StepDto StepDto { get; set; }
    }
}
