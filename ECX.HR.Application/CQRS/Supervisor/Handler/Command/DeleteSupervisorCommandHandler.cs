using AutoMapper;
using ECX.HR.Application.CQRS.Supervisor.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Supervisor.Handler.Command
{
    public class DeleteSupervisorCommandHandler : IRequestHandler<DeleteSupervisorCommand>
    {
        private ISupervisiorRepository _SupervisorRepository;
        private IMapper _mapper;
        public DeleteSupervisorCommandHandler(ISupervisiorRepository SupervisorRepository, IMapper mapper)
        {
            _SupervisorRepository = SupervisorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSupervisorCommand request, CancellationToken cancellationToken)
        {
            var Supervisor = await _SupervisorRepository.GetById(request.Id);
            await _SupervisorRepository.Delete(Supervisor);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteSupervisorCommand>.Handle(DeleteSupervisorCommand request, CancellationToken cancellationToken)
        {
            var Supervisor = await _SupervisorRepository.GetById(request.Id);
            if(Supervisor == null) 
                throw new NotFoundException(nameof(Supervisor), request.Id);
            Supervisor.Status = 1;
            await _SupervisorRepository.Update(Supervisor);
        }
    }
}
