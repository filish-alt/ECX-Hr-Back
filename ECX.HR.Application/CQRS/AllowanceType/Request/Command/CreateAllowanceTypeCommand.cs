using ECX.HR.Application.DTOs.Allowances.cs;
using ECX.HR.Application.DTOs.AllowanceType;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AllowanceType.Request.Command
{
    public class CreateAllowanceTypeCommand : IRequest<BaseCommandResponse>
    {
        public AllowanceTypeDto AllowanceTypeDto { get; set; }
    }
}
