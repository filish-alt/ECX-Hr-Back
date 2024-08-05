using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Spouse.Request.Queries;

using ECX.HR.Application.DTOs.Spouses;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Handler.Queries
{
    public class GetSpouseDetailRequestHandler : IRequestHandler<GetSpouseDetailRequest, List<SpouseDto>>
    {
        private ISpouseRepository _SpouseRepository;
        private IMapper _mapper;
        public GetSpouseDetailRequestHandler(ISpouseRepository SpouseRepository, IMapper mapper)
        {
            _SpouseRepository = SpouseRepository;
            _mapper = mapper;
        }
        public async Task<List<SpouseDto>> Handle(GetSpouseDetailRequest request, CancellationToken cancellationToken)
        {
            var spouse =await _SpouseRepository.GetByEmpId(request.EmpId);
          
            if (spouse == null || !spouse.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(spouse), request.EmpId);

            else
                return _mapper.Map<List<SpouseDto>>(spouse);
        }
    }
}
