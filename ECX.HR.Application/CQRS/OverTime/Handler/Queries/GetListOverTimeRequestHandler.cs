using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.OverTime.Request.Queries;
using ECX.HR.Application.DTOs.OverTime;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Handler.Queries
{
    internal class GetListOverTimeRequestHandler : IRequestHandler<GetListOverTimeRequest, List<OverTimeDto>>
    {
        private IOverTimeRepository _OverTimeRepository;
        private IMapper _mapper;
        public GetListOverTimeRequestHandler(IOverTimeRepository OverTimeRepository, IMapper mapper)
        {
            _OverTimeRepository = OverTimeRepository;
            _mapper = mapper;
        }
        public async Task<List<OverTimeDto>> Handle(GetListOverTimeRequest request, CancellationToken cancellationToken)
        {
            var OverTime = await _OverTimeRepository.GetAll();
            return _mapper.Map<List<OverTimeDto>>(OverTime);
        }
    }
}
