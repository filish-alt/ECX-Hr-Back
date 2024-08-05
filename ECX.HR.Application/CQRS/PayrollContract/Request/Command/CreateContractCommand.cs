
using ECX.HR.Application.DTOs.PayrollContract;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayrollContract.Request.Command
{
    public class CreateContractCommand : IRequest<BaseCommandResponse>
    {
        public PayrollContractDto PayrollContractDto { get; set; }
    }
}
