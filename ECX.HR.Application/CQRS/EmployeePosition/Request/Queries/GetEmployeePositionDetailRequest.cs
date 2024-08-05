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
    public class GetEmployeePositionDetailRequest :IRequest<EmployeePositionDto>
    {
       // public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public int status { get; set; }
    }
}
