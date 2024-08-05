using AutoMapper;
using ECX.HR.Application.ContractS.Persistence;
using ECX.HR.Application.CQRS.PayrollContract.Request.Queries;
using ECX.HR.Application.DTOs.PayrollContract;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Contract.Handler.Queries
{
    public class GetContractDetailRequestHandler : IRequestHandler<GetContractDetailRequest, PayrollContractDto>
    {
        private IPayrollContractRepository _ContractRepository;
        private IMapper _mapper;
        public GetContractDetailRequestHandler(IPayrollContractRepository ContractRepository, IMapper mapper)
        {
            _ContractRepository = ContractRepository;
            _mapper = mapper;
        }
        public async Task<PayrollContractDto> Handle(GetContractDetailRequest request, CancellationToken cancellationToken)
        {
            var Contract = await _ContractRepository.GetById(request.Id);
            if (Contract == null || Contract.Status != 0)
                throw new NotFoundException(nameof(Contract), request.Id);

            else
                return _mapper.Map<PayrollContractDto>(Contract);
        }
    }
}

