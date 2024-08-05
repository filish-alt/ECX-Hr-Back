using AutoMapper;
using ECX.HR.Application.CQRS.Termination.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Termination.Handler.Command
{
    public class DeleteTerminationCommandHandler : IRequestHandler<DeleteTerminationCommand>
    {
        private ITerminationRepository _TerminationRepository;
        private IMapper _mapper;
        public DeleteTerminationCommandHandler(ITerminationRepository TerminationRepository, IMapper mapper)
        {
            _TerminationRepository = TerminationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTerminationCommand request, CancellationToken cancellationToken)
        {
            var Termination = await _TerminationRepository.GetById(request.Id);
            Termination.Status = 1;
            await _TerminationRepository.Update(Termination);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteTerminationCommand>.Handle(DeleteTerminationCommand request, CancellationToken cancellationToken)
        {
            var Termination = await _TerminationRepository.GetById(request.Id);
            if(Termination == null) 
                throw new NotFoundException(nameof(Termination), request.Id);
            Termination.Status = 1;
            await _TerminationRepository.Update(Termination);
        }
    }
}
