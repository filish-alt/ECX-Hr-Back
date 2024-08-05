
using ECX.HR.Application.DTOs.Branchs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Branch.Request.Command
{
    public class UpdateBranchCommand :IRequest<Unit>
    {
        public BranchDto BranchDto { get; set; }
    }
}
