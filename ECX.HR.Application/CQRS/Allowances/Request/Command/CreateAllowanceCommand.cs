
using ECX.HR.Application.DTOs.Allowances.cs;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowances.Request.Command
{
    public class CreateAllowanceCommand : IRequest<BaseCommandResponse>
    {
        public AllowanceDto AllowanceDto { get; set; }
    }
}
