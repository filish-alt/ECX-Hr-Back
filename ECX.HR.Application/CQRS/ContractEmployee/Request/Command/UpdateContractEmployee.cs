using ECX.HR.Application.DTOs.EmployeePositions;
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Request.Command
{
    public class UpdateContractEmployee : IRequest<Unit>
    {
        public ContractRegistrationDto ContractEmpDto { get; set; }
    }
}
