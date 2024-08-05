using ECX.HR.Application.DTOs.Education;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Education.Request.Command
{
    public class CreateEducationCommand : IRequest<BaseCommandResponse>
    {
        public EducationDto EducationDto { get; set; }
    }
}
