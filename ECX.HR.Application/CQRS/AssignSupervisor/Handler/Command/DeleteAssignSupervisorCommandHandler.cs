using AutoMapper;

using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AssignSupervisor.Request.Command;

namespace ECX.HR.Application.CQRS.AssignSupervisor.Handler.Command
{
    public class DeleteAssignSupervisorCommandHandler : IRequestHandler<DeleteAssignSupervisorCommand>
    {
        private IAssignSupervisorRepository _AssignSupervisorRepository;
        private IMapper _mapper;
        public DeleteAssignSupervisorCommandHandler(IAssignSupervisorRepository AssignSupervisorRepository, IMapper mapper)
        {
            _AssignSupervisorRepository = AssignSupervisorRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteAssignSupervisorCommand request, CancellationToken cancellationToken)
        {
            var AssignSupervisor = await _AssignSupervisorRepository.GetById(request.Id);

            if (AssignSupervisor == null)
                throw new NotFoundException(nameof(AssignSupervisor), request.Id);

            // Assuming '1' represents the 'Deleted' status
            AssignSupervisor.Status = 1;

            await _AssignSupervisorRepository.Update(AssignSupervisor); // Update the AssignSupervisor with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteAssignSupervisorCommand>.Handle(DeleteAssignSupervisorCommand request, CancellationToken cancellationToken)
        {
            var AssignSupervisor = await _AssignSupervisorRepository.GetById(request.Id);
            if (AssignSupervisor == null)
                throw new NotFoundException(nameof(AssignSupervisor), request.Id);
            AssignSupervisor.Status = 1;
            await _AssignSupervisorRepository.Update(AssignSupervisor);
        }
    }
}
