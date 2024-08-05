using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Bank.Request.Queries;
using ECX.HR.Application.CQRS.Bank;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.DTOs.Bank;

namespace ECX.HR.Application.CQRS.Bank.Handler.Queries
{
    public class GetBankListRequestHandler : IRequestHandler<GetBankListRequest, List<BankDto>>
    {
        private IBankRepository _BankRepository;
        private IMapper _mapper;
        public GetBankListRequestHandler(IBankRepository BankRepository, IMapper mapper)
        {
            _BankRepository = BankRepository;
            _mapper = mapper;
        }
        public async Task<List<BankDto>> Handle(GetBankListRequest request, CancellationToken cancellationToken)
        {
            var Bank = await _BankRepository.GetAll();
            var activeBank = Bank.Where(Bank => Bank.Status == 0).ToList();
            return _mapper.Map<List<BankDto>>(activeBank);
        }
    }
}
