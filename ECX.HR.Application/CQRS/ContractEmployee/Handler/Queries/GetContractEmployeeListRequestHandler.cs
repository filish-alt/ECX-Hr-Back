using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Branch.Request.Queries;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Queries;
using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Handler.Queries
{
    public class GetContractEmployeeListRequestHandler : IRequestHandler<GetContractEmployeeList, List<ContractRegistrationDto>>
    {
        private IContractEmployeesRegstration _contractEmployeesRegstration;
        private IMapper _mapper;
        public GetContractEmployeeListRequestHandler(IContractEmployeesRegstration contractEmployeesRegstration, IMapper mapper)
        {
            _contractEmployeesRegstration = contractEmployeesRegstration;
            _mapper = mapper;
        }
        public async Task<List<ContractRegistrationDto>> Handle(GetContractEmployeeList request, CancellationToken cancellationToken)
        {
            var contract = await _contractEmployeesRegstration.GetAll();
            var activecontract = contract.Where(contract => contract.Status == 0).ToList();
            return _mapper.Map<List<ContractRegistrationDto>>(activecontract);
        }
    }
}
