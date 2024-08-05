using AutoMapper;
using ECX.HR.Application.ContractS.Persistence;
using ECX.HR.Application.CQRS.PayrollContract.Request;
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayrollContract.Handler.Queries
{
    public class GetContractListRequestHandler : IRequestHandler<GetContractListRequest, List<PayrollContractDto>>
    {
        private IPayrollContractRepository _ContractRepository;
        private IMapper _mapper;
        public GetContractListRequestHandler(IPayrollContractRepository ContractRepository, IMapper mapper)
        {
            _ContractRepository = ContractRepository;
            _mapper = mapper;
        }
        public async Task<List<PayrollContractDto>> Handle(GetContractListRequest request, CancellationToken cancellationToken)
        {
            var Contract = await _ContractRepository.GetAll();
            var activeContract = Contract.Where(Contract => Contract.Status == 0).ToList();
            return _mapper.Map<List<PayrollContractDto>>(activeContract);
        }
    }
}
