using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Supervisor.Request.Queries;

using ECX.HR.Application.DTOs.Supervisors;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Supervisor.Handler.Queries
{
    public class GetSupervisorDetailRequestHandler : IRequestHandler<GetSupervisorDetailRequest, SupervisorDto>
    {
        private ISupervisiorRepository _SupervisorRepository;
        private IMapper _mapper;
        public GetSupervisorDetailRequestHandler(ISupervisiorRepository SupervisorRepository, IMapper mapper)
        {
            _SupervisorRepository = SupervisorRepository;
            _mapper = mapper;
        }
        public async Task<SupervisorDto> Handle(GetSupervisorDetailRequest request, CancellationToken cancellationToken)
        {
            var supervisor =await _SupervisorRepository.GetById(request.Id);
           
            if (supervisor == null || supervisor.Status != 0)
                throw new NotFoundException(nameof(supervisor), request.Id);

            else
                return _mapper.Map<SupervisorDto>(supervisor);
        }
    }
}
