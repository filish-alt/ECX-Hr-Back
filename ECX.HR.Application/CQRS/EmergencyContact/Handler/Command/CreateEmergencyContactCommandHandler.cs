using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmergencyContact.Request.Command;

using ECX.HR.Application.DTOs.EmergencyContacts.Validators;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmergencyContact.Handler.Command
{
    public class CreateEmergencyContactCommandHandler : IRequestHandler<CreateEmergencyContactCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IEmergencyContactRepository _EmergencyContactRepository;
        private IMapper _mapper;
        public CreateEmergencyContactCommandHandler(IEmergencyContactRepository EmergencyContactRepository, IMapper mapper)
        {
            _EmergencyContactRepository = EmergencyContactRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new EmergencyContactDtoValidator();
            var validationResult =await validator.ValidateAsync(request.EmergencyContactDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var emergencyContact = _mapper.Map<EmergencyContacts>(request.EmergencyContactDto);
            emergencyContact.Id = Guid.NewGuid();
            var data =await _EmergencyContactRepository.Add(emergencyContact);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
