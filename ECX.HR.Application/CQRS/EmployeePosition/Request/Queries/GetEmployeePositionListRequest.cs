using ECX.HR.Application.DTOs.Department;
using ECX.HR.Application.DTOs.EmployeePositions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeePosition.Request.Queries
{
    public class GetEmployeePositionListRequest :IRequest<List<EmployeePositionDto>>
    {
       
    }
}
