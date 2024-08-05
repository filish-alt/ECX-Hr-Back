using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Allowance.Request.Queries;

using ECX.HR.Application.DTOs.Allowances.cs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowance.Handler.Queries
{
    public class GetAllowanceListRequestHandler : IRequestHandler<GetAllowanceListRequest, List<AllowanceDto>>
    {
        private IAllwoanceRepository _AllowanceRepository;
        private IMapper _mapper;
        public GetAllowanceListRequestHandler(IAllwoanceRepository AllowanceRepository, IMapper mapper)
        {
            _AllowanceRepository= AllowanceRepository;
            _mapper = mapper;
        }
        public async Task<List<AllowanceDto>> Handle(GetAllowanceListRequest request, CancellationToken cancellationToken)
        {
            var allowance =await _AllowanceRepository.GetAll();
            return _mapper.Map<List<AllowanceDto>>(allowance);
        }
    }
}
