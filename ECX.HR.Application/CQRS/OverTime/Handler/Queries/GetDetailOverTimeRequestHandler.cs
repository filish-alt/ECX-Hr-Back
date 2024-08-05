using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.OverTime.Request.Queries;
using ECX.HR.Application.DTOs.OverTime;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Handler.Queries
{
    internal class GetDetailOverTimeRequestHandler : IRequestHandler<GetDetailOverTimeRequest, OverTimeDto>
    {
        private IOverTimeRepository _OverTimeRepository;
        private IMapper _mapper;
        public GetDetailOverTimeRequestHandler(IOverTimeRepository OverTimeRepository, IMapper mapper)
        {
            _OverTimeRepository = OverTimeRepository;
            _mapper = mapper;
        }
        public async Task<OverTimeDto> Handle(GetDetailOverTimeRequest request, CancellationToken cancellationToken)
        {
            var OverTime = await _OverTimeRepository.GetByEmpId(request.Empid);

            if (OverTime == null)
                throw new NotFoundException(nameof(OverTime), request.Empid);

            else
                return _mapper.Map<OverTimeDto>(OverTime);
        }
    }
}
