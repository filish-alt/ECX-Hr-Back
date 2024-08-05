using ECX.HR.Application.DTOs.Schedule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Request.Queries
{
    public class getuser : IRequest<List<NumOfRunDto>>
    {

    }
}
