using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Branch.Request.Queries;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Queries;
using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.PayrollContract;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Handler.Queries
{
    public class GetContractEmployeeDetailRequestHandler : IRequestHandler<GetContractEmployeeDetail, ContractRegistrationDto>
    {
        private IContractEmployeesRegstration _contractEmployeesRegstration;
        private IMapper _mapper;
        public GetContractEmployeeDetailRequestHandler(IContractEmployeesRegstration contractEmployeesRegstration, IMapper mapper)
        {
            _contractEmployeesRegstration = contractEmployeesRegstration;
            _mapper = mapper;
        }
        public async Task<ContractRegistrationDto> Handle(GetContractEmployeeDetail request, CancellationToken cancellationToken)
        {
            var contract = await _contractEmployeesRegstration.GetById(request.Id);
            if (contract == null || contract.Status != 0)
                throw new NotFoundException(nameof(contract), request.Id);

            else
                return _mapper.Map<ContractRegistrationDto>(contract);
        }
    }
}
