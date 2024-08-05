using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.DepositAutorization.Request.Queries;

using ECX.HR.Application.DTOs.DepositAutorizations;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DepositAutorization.Handler.Queries
{
    public class GetDepositAutorizationDetailRequestHandler : IRequestHandler<GetDepositAutorizationDetailRequest, DepositAutorizationDto>
    {
        private IDepositAutorizationRepository _DepositAutorizationRepository;
        private IMapper _mapper;
        public GetDepositAutorizationDetailRequestHandler(IDepositAutorizationRepository DepositAutorizationRepository, IMapper mapper)
        {
            _DepositAutorizationRepository = DepositAutorizationRepository;
            _mapper = mapper;
        }
        public async Task<DepositAutorizationDto> Handle(GetDepositAutorizationDetailRequest request, CancellationToken cancellationToken)
        {
            var depositAutorization =await _DepositAutorizationRepository.GetByEmpId(request.EmpId);
          /* 
            if (depositAutorization == null || depositAutorization.Status != 0)
                throw new NotFoundException(nameof(depositAutorization), request.EmpId);

            else*/
                return _mapper.Map<DepositAutorizationDto>(depositAutorization);
        }
    }
}
