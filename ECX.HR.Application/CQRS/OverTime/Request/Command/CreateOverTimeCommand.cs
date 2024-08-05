using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.OrganizationalProfiles;
using ECX.HR.Application.DTOs.OverTime;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Request.Command
{
    public class CreateOverTimeCommand : IRequest<BaseCommandResponse>
    {
        public OverTimeDto OverTimeDto { get; set; }

        public CreateOverTimeCommand(OverTimeDto overTimeDto)
        {
            OverTimeDto = overTimeDto;
        }
        public CreateOverTimeCommand()
        {
            // Empty constructor
        }
    }
}
