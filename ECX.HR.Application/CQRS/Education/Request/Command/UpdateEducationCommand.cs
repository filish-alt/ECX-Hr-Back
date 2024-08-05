using ECX.HR.Application.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Education.Request.Command
{
    public class UpdateEducationCommand :IRequest<Unit>
    {
        public EducationDto EducationDto { get; set; }
    }
}
