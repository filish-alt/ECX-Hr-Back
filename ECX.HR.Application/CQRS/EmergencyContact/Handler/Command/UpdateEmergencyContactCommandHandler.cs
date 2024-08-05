using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmergencyContact.Request.Command;

using ECX.HR.Application.DTOs.EmergencyContacts.Validators;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmergencyContact.Handler.Command
{
    public class UpdateEmergencyContactCommandHandler : IRequestHandler<UpdateEmergencyContactCommand, Unit>
    {
        private IEmergencyContactRepository _EmergencyContactRepository;
        private IMapper _mapper;
        public UpdateEmergencyContactCommandHandler(IEmergencyContactRepository EmergencyContactRepository, IMapper mapper)
        {
            _EmergencyContactRepository = EmergencyContactRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new EmergencyContactDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmergencyContactDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var EmergencyContact = await _EmergencyContactRepository.GetById(request.EmergencyContactDto.Id);
            _mapper.Map(request.EmergencyContactDto, EmergencyContact);
            await _EmergencyContactRepository.Update(EmergencyContact);
            return Unit.Value;
        }
    }
}
