
using ECX.HR.Application.DTOs.MedicalFunds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Request.Queries
{
    public class GetMedicalFundDetailRequest : IRequest<List<MedicalFundDto>>
    {
        public Guid Id { get; set; }
    }
}
