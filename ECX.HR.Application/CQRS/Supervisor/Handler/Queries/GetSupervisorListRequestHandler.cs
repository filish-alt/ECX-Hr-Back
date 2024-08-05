using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Supervisor.Request.Queries;

using ECX.HR.Application.DTOs.Supervisors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Supervisor.Handler.Queries
{
    public class GetSupervisorListRequestHandler : IRequestHandler<GetSupervisorListRequest, List<SupervisorDto>>
    {
        private ISupervisiorRepository _SupervisorRepository;
        private IMapper _mapper;
        public GetSupervisorListRequestHandler(ISupervisiorRepository SupervisorRepository, IMapper mapper)
        {
            _SupervisorRepository= SupervisorRepository;
            _mapper = mapper;
        }
        public async Task<List<SupervisorDto>> Handle(GetSupervisorListRequest request, CancellationToken cancellationToken)
        {
            var Supervisor =await _SupervisorRepository.GetAll();
            var supervisorLevel = Supervisor.Where(supervisor => supervisor.Status == 0).ToList();
            return _mapper.Map<List<SupervisorDto>>(supervisorLevel);
        }
    }
}
