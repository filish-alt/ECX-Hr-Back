using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.DepositAutorization.Request.Queries;

using ECX.HR.Application.DTOs.DepositAutorizations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DepositAutorization.Handler.Queries
{
    public class GetDepositAutorizationListRequestHandler : IRequestHandler<GetDepositAutorizationListRequest, List<DepositAutorizationDto>>
    {
        private IDepositAutorizationRepository _DepositAutorizationRepository;
        private IMapper _mapper;
        public GetDepositAutorizationListRequestHandler(IDepositAutorizationRepository DepositAutorizationRepository, IMapper mapper)
        {
            _DepositAutorizationRepository= DepositAutorizationRepository;
            _mapper = mapper;
        }
        public async Task<List<DepositAutorizationDto>> Handle(GetDepositAutorizationListRequest request, CancellationToken cancellationToken)
        {
            var DepositAutorization =await _DepositAutorizationRepository.GetAll();
            var activeDepositAutorization = DepositAutorization.Where(depositAutorization => depositAutorization.Status == 0).ToList();

            return _mapper.Map<List<DepositAutorizationDto>>(activeDepositAutorization);
        }
    }
}
