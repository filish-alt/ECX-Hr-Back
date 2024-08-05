
using ECX.HR.Application.DTOs.Spouses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Request.Command
{
    public class UpdateSpouseCommand :IRequest<Unit>
    {
        public SpouseDto SpouseDto { get; set; }
    }
}
