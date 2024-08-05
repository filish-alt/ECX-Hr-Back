using ECX.HR.Application.DTOs.Step;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Request.Queries
{
    public class GetStepListRequest :IRequest<List<StepDto>>
    {
       
    }
}
