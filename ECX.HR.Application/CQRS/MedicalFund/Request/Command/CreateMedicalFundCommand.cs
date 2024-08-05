using ECX.HR.Application.DTOs.ActingAssigment;
using ECX.HR.Application.DTOs.MedicalFunds;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Request.Command
{
    public class CreateMedicalFundCommand : IRequest<BaseCommandResponse>
    {
        public MedicalFundDto MedicalFundDto { get; set; }
    }
}
