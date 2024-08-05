
using ECX.HR.Application.DTOs.DepositAutorizations;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DepositAutorization.Request.Command
{
    public class CreateDepositAutorizationCommand : IRequest<BaseCommandResponse>
    {
        public DepositAutorizationDto DepositAutorizationDto { get; set; }
    }
}
