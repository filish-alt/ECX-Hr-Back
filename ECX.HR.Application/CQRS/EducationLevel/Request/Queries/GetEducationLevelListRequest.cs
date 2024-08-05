
using ECX.HR.Application.DTOs.EducationLevels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EducationLevel.Request.Queries
{
    public class GetEducationLevelListRequest :IRequest<List<EducationLevelDto>>
    {
       
    }
}
