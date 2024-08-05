using ECX.HR.Application.DTOs.Step;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Request.Command
{
    public class UpdateStepCommand :IRequest<Unit>
    {
        public StepDto StepDto { get; set; }
    }
}
