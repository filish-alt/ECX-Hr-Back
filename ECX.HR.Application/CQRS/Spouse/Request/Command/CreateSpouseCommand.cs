
using ECX.HR.Application.DTOs.MedicalBalance;
using ECX.HR.Application.DTOs.Spouses;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Request.Command
{
    public class CreateSpouseCommand : IRequest<BaseCommandResponse>
    {
        public SpouseDto SpouseDto { get; set; }
        public MedicalBalanceDto MedicalDto { get; set; }
    }
}
