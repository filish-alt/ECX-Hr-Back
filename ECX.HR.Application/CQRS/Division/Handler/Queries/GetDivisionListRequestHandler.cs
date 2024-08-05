using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Division.Request.Queries;
using ECX.HR.Application.DTOs.Division;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Division.Handler.Queries
{
    public class GetDivisionListRequestHandler : IRequestHandler<GetDivisionListRequest, List<DivisionDto>>
    {
        private IDivisionRepository _DivisionRepository;
        private IMapper _mapper;
        public GetDivisionListRequestHandler(IDivisionRepository DivisionRepository, IMapper mapper)
        {
            _DivisionRepository= DivisionRepository;
            _mapper = mapper;
        }
        public async Task<List<DivisionDto>> Handle(GetDivisionListRequest request, CancellationToken cancellationToken)
        {
            var Division =await _DivisionRepository.GetAll();
            var activeDivision = Division.Where(division => division.Status == 0).ToList();
            return _mapper.Map<List<DivisionDto>>(activeDivision);
        }
    }
}
