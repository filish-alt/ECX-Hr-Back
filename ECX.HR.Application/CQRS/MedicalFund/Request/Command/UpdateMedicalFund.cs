
using ECX.HR.Application.DTOs.MedicalFunds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Request.Command
{
    public class UpdateMedicalFund : IRequest<Unit>
    {
        public MedicalFundDto MedicalFundDto { get; set; }
    }
}
