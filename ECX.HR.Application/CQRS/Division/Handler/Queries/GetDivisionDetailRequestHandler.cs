using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Division.Request.Queries;
using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.DTOs.DepositAutorizations;
using ECX.HR.Application.DTOs.Division;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Division.Handler.Queries
{
    public class GetDivisionDetailRequestHandler : IRequestHandler<GetDivisionDetailRequest, DivisionDto>
    {
        private IDivisionRepository _DivisionRepository;
        private IMapper _mapper;
        public GetDivisionDetailRequestHandler(IDivisionRepository DivisionRepository, IMapper mapper)
        {
            _DivisionRepository = DivisionRepository;
            _mapper = mapper;
        }
        public async Task<DivisionDto> Handle(GetDivisionDetailRequest request, CancellationToken cancellationToken)
        {
            var division =await _DivisionRepository.GetById(request.DivisionId);
            
            if (division == null || division.Status != 0)
                throw new NotFoundException(nameof(division), request.DivisionId);

            else
                return _mapper.Map<DivisionDto>(division);
        }
    }
}
