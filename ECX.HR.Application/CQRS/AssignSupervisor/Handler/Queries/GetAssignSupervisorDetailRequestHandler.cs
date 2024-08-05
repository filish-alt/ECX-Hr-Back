using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AssignSupervisor.Request.Queries;

using ECX.HR.Application.DTOs.AssignSupervisor;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisors.Handler.Queries
{
    public class GetAssignSupervisorDetailRequestHandler : IRequestHandler<GetAssignSupervisorDetailRequest, AssignSupervisorDto>
    {
        private IAssignSupervisorRepository _AssignSupervisorRepository;
     
        private IMapper _mapper;
        public GetAssignSupervisorDetailRequestHandler(IAssignSupervisorRepository AssignSupervisorRepository ,IMapper mapper)
        {
           _AssignSupervisorRepository = AssignSupervisorRepository;
           
            _mapper = mapper;
        }
        public async Task<AssignSupervisorDto> Handle(GetAssignSupervisorDetailRequest request, CancellationToken cancellationToken)
        {
            var AssignSupervisor = await _AssignSupervisorRepository.GetById(request.Id);

            if (AssignSupervisor == null || AssignSupervisor.Status != 0)
                throw new NotFoundException(nameof(AssignSupervisor), request.PositionId);

            return _mapper.Map<AssignSupervisorDto>(AssignSupervisor);
        }

    }
}
