using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Command;
using ECX.HR.Application.DTOs.OrganizationalProfile.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Handler.Command
{
    public class UpdateOrganizationalProfileCommandHandler : IRequestHandler<UpdateOrganizationalProfileCommand, Unit>
    {
        private IOrganizationalProfileRepository _OrganizationalProfileRepository;
        private IMapper _mapper;
        public UpdateOrganizationalProfileCommandHandler(IOrganizationalProfileRepository OrganizationalProfileRepository, IMapper mapper)
        {
            _OrganizationalProfileRepository = OrganizationalProfileRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrganizationalProfileCommand request, CancellationToken cancellationToken)
        {
            var validator = new OrganizationalProfileDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OrganizationalProfileDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var OrganizationalProfile = await _OrganizationalProfileRepository.GetById(request.OrganizationalProfileDto.Id);
            _mapper.Map(request.OrganizationalProfileDto, OrganizationalProfile);
            await _OrganizationalProfileRepository.Update(OrganizationalProfile);
            return Unit.Value;
        }
    }
}
