﻿
using ECX.HR.Application.DTOs.WorkExperiences;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.WorkExperience.Request.Command
{
    public class CreateWorkExperienceCommand : IRequest<BaseCommandResponse>
    {
        public WorkExperienceDto WorkExperienceDto { get; set; }
    }
}
