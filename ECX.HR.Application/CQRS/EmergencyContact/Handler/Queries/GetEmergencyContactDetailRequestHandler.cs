using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmergencyContact.Request.Queries;

using ECX.HR.Application.DTOs.EmergencyContacts;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmergencyContact.Handler.Queries
{
    public class GetEmergencyContactDetailRequestHandler : IRequestHandler<GetEmergencyContactDetailRequest, List<EmergencyContactDto>>
    {
        private IEmergencyContactRepository _EmergencyContactRepository;
        private IMapper _mapper;
        public GetEmergencyContactDetailRequestHandler(IEmergencyContactRepository EmergencyContactRepository, IMapper mapper)
        {
            _EmergencyContactRepository = EmergencyContactRepository;
            _mapper = mapper;
        }
        public async Task<List<EmergencyContactDto>> Handle(GetEmergencyContactDetailRequest request, CancellationToken cancellationToken)
        {
            var emergencyContact =await _EmergencyContactRepository.GetByEmpId(request.EmpId);
          
            if (emergencyContact == null || !emergencyContact.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(emergencyContact), request.EmpId);

            else
                return _mapper.Map<List<EmergencyContactDto>>(emergencyContact);
        }
    }
}
