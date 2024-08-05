using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Termination.Request.Queries;
using ECX.HR.Application.DTOs.Termination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Termination.Handler.Queries
{
    public class GetTerminationListRequestHandler : IRequestHandler<GetTerminationListRequest, List<TerminationDto>>
    {
        private ITerminationRepository _TerminationRepository;
        private IMapper _mapper;
        public GetTerminationListRequestHandler(ITerminationRepository TerminationRepository, IMapper mapper)
        {
            _TerminationRepository= TerminationRepository;
            _mapper = mapper;
        }
        public async Task<List<TerminationDto>> Handle(GetTerminationListRequest request, CancellationToken cancellationToken)
        {
            var Termination =await _TerminationRepository.GetAll();
            var activeTermination = Termination.Where(Termination => Termination.Status == 0).ToList();
            return _mapper.Map<List<TerminationDto>>(activeTermination);
        }
    }
}
