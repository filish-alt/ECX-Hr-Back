using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Outsource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Request.Command
{
    public class UpdateOutsourceCommand : IRequest<Unit>
    {
        public OutsourceDto OutsourceDto { get; set; }
    }
}
