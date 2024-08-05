using ECX.HR.Application.DTOs.Division;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Division.Request.Command
{
    public class UpdateDivisionCommand :IRequest<Unit>
    {
        public DivisionDto DivisionDto { get; set; }
    }
}
