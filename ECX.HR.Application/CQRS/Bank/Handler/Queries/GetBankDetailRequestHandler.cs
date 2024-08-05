using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Bank.Request.Queries;
using ECX.HR.Application.CQRS.Bank;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.DTOs.Bank;

namespace ECX.HR.Application.CQRS.Bank.Handler.Queries
{
    public class GetBankDetailRequestHandler : IRequestHandler<GetBankDetailRequest, BankDto>
    {
        private IBankRepository _BankRepository;
        private IMapper _mapper;
        public GetBankDetailRequestHandler(IBankRepository BankRepository, IMapper mapper)
        {
            _BankRepository = BankRepository;
            _mapper = mapper;
        }
        public async Task<BankDto> Handle(GetBankDetailRequest request, CancellationToken cancellationToken)
        {
            var Bank = await _BankRepository.GetById(request.Id);

            if (Bank == null || Bank.Status != 0)
                throw new NotFoundException(nameof(Bank), request.Id);

            else
                return _mapper.Map<BankDto>(Bank);
        }
    }
}
