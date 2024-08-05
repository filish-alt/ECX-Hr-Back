using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Position.Request.Queries;

using ECX.HR.Application.DTOs.Positions;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Position.Handler.Queries
{
    public class GetPositionDetailRequestHandler : IRequestHandler<GetPositionDetailRequest, PositionDto>
    {
        private IPositionRepository _PositionRepository;
        private IMapper _mapper;
        public GetPositionDetailRequestHandler(IPositionRepository PositionRepository, IMapper mapper)
        {
            _PositionRepository = PositionRepository;
            _mapper = mapper;
        }
        public async Task<PositionDto> Handle(GetPositionDetailRequest request, CancellationToken cancellationToken)
        {
            var position =await _PositionRepository.GetById(request.PositionId);
           
            if (position == null || position.Status != 0)
                throw new NotFoundException(nameof(position), request.PositionId);

            else
                return _mapper.Map<PositionDto>(position);
        }
    }
}
