
using ECX.HR.Application.DTOs.MedicalFunds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Request.Queries
{
    public class GetMedicalFundListRequest : IRequest<List<MedicalFundDto>>
    {
    }
}
