


using ECX.HR.Application.DTOs.EmployeeStatuss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeeStatus.Request.Queries
{
    public class GetEmployeeStatusDetailRequest :IRequest<EmployeeStatusDto>
    {
        public Guid Id { get; set; }
    }
}
