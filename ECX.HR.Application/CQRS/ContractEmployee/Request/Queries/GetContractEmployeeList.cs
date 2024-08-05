using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Request.Queries
{
    public class GetContractEmployeeList : IRequest<List<ContractRegistrationDto>>
    {

    }
}
