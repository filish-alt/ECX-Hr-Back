using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.Outsource;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Request.Command
{
    public class CreateOutsourceCommand : IRequest<BaseCommandResponse>
    {
        public OutsourceDto OutsourceDto { get; set; }


    }
}
