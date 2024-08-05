using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.OverTime;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Request.Command
{
    public class DeleteOverTimeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
