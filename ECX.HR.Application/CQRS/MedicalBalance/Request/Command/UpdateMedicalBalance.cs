
using ECX.HR.Application.DTOs.MedicalBalance;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Request.Command
{
    public class UpdateMedicalBalance : IRequest<Unit>
    {
        public MedicalBalanceDto MedicalBalanceDto { get; set; }
    }
}
