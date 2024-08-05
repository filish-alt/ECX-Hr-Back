
using ECX.HR.Application.DTOs.Allowances.cs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowance.Request.Command
{
    public class UpdateAllowanceCommand :IRequest<Unit>
    {
        public AllowanceDto AllowanceDto { get; set; }
    }
}
