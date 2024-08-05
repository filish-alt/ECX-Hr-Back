
using ECX.HR.Application.DTOs.EducationLevels;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EducationLevel.Request.Command
{
    public class CreateEducationLevelCommand : IRequest<BaseCommandResponse>
    {
        public EducationLevelDto EducationLevelDto { get; set; }
    }
}
