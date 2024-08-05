
using ECX.HR.Application.DTOs.Branchs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Branch.Request.Queries
{
    public class GetBranchDetailRequest :IRequest<BranchDto>
    {
        public Guid Id { get; set; }
    }
}
