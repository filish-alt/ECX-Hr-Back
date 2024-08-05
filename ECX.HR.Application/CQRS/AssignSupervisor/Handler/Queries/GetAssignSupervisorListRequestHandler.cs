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
    public class GetAssignSupervisorListRequestHandler: IRequestHandler<GetAssignSupervisorListRequest, List<AssignSupervisorDto>>
    {
        private IAssignSupervisorRepository _AssignSupervisorRepository;
        private IMapper _mapper;
        public GetAssignSupervisorListRequestHandler(IAssignSupervisorRepository AssignSupervisorRepository, IMapper mapper)
        {
            _AssignSupervisorRepository= AssignSupervisorRepository;
            _mapper = mapper;
        }
        public async Task<List<AssignSupervisorDto>> Handle(GetAssignSupervisorListRequest request, CancellationToken cancellationToken)
        {
            var AssignSupervisores = await _AssignSupervisorRepository.GetAll();

            var activeAssignSupervisores = AssignSupervisores.Where(AssignSupervisor => AssignSupervisor.Status == 0).ToList();

            return _mapper.Map<List<AssignSupervisorDto>>(activeAssignSupervisores);
        }

    }
}
