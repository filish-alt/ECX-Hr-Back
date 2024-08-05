
using ECX.HR.Application.DTOs.DepositAutorizations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DepositAutorization.Request.Command
{
    public class UpdateDepositAutorizationCommand :IRequest<Unit>
    {
        public DepositAutorizationDto DepositAutorizationDto { get; set; }
    }
}
