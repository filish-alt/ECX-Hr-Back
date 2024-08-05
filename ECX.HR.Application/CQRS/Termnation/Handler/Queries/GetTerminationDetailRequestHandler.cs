using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Termination.Request.Queries;
using ECX.HR.Application.DTOs.Termination;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Handler.Queries
{
    public class GetTerminationDetailRequestHandler : IRequestHandler<GetTerminationDetailRequest, List<TerminationDto>>
    {
        private ITerminationRepository _SpouseRepository;
        private IMapper _mapper;
        public GetTerminationDetailRequestHandler(ITerminationRepository SpouseRepository, IMapper mapper)
        {
            _SpouseRepository = SpouseRepository;
            _mapper = mapper;
        }
        public async Task<List<TerminationDto>> Handle(GetTerminationDetailRequest request, CancellationToken cancellationToken)
        {
            var spouse =await _SpouseRepository.GetByEmpId(request.EmpId);
          
            if (spouse == null || !spouse.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(spouse), request.EmpId);

            else
                return _mapper.Map<List<TerminationDto>>(spouse);
        }
    }
}
