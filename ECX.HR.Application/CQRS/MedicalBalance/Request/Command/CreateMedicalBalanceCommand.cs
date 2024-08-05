
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.MedicalBalance;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Request.Command
{
    public class CreateMedicalBalanceCommand : IRequest<BaseCommandResponse>
    {
        public MedicalBalanceDto MedicalBalanceDto { get; set; }

        public CreateMedicalBalanceCommand(MedicalBalanceDto medicalBalanceDto)
        {
            MedicalBalanceDto = medicalBalanceDto;
        }
        public CreateMedicalBalanceCommand()
        {
            // Empty constructor
        }
}
}
