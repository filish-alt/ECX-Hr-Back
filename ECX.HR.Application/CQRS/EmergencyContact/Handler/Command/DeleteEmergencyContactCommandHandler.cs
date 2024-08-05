using AutoMapper;
using ECX.HR.Application.CQRS.EmergencyContact.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.EmergencyContact.Handler.Command
{
    public class DeleteEmergencyContactCommandHandler : IRequestHandler<DeleteEmergencyContactCommand>
    {
        private IEmergencyContactRepository _EmergencyContactRepository;
        private IMapper _mapper;
        public DeleteEmergencyContactCommandHandler(IEmergencyContactRepository EmergencyContactRepository, IMapper mapper)
        {
            _EmergencyContactRepository = EmergencyContactRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            var EmergencyContact = await _EmergencyContactRepository.GetById(request.Id);
            EmergencyContact.Status = 1;
            await _EmergencyContactRepository.Update(EmergencyContact);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteEmergencyContactCommand>.Handle(DeleteEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            var EmergencyContact = await _EmergencyContactRepository.GetById(request.Id);
            if(EmergencyContact == null) 
                throw new NotFoundException(nameof(EmergencyContact), request.Id);
            EmergencyContact.Status = 1;
            await _EmergencyContactRepository.Update(EmergencyContact);
        }
    }
}
