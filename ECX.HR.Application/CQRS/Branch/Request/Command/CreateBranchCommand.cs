
using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Branch.Request.Command
{
    public class CreateBranchCommand : IRequest<BaseCommandResponse>
    {
        public BranchDto BranchDto { get; set; }
    }
}
