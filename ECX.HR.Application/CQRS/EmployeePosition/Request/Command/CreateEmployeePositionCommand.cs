
using ECX.HR.Application.DTOs.EmployeePositions;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeePosition.Request.Command
{
    public class CreateEmployeePositionCommand : IRequest<BaseCommandResponse>
    {
        public EmployeePositionDto EmployeePositionDto { get; set; }
    }
}
