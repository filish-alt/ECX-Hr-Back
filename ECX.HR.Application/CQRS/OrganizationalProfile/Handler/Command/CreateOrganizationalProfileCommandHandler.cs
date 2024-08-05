using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Command;
using ECX.HR.Application.DTOs.OrganizationalProfile.Validator;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Handler.Command
{
    public class CreateOrganizationalProfileCommandHandler : IRequestHandler<CreateOrganizationalProfileCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IOrganizationalProfileRepository _OrganizationalProfileRepository;
        private IMapper _mapper;
        public CreateOrganizationalProfileCommandHandler(IOrganizationalProfileRepository OrganizationalProfileRepository, IMapper mapper)
        {
            this.OrganizationalProfileRepository = OrganizationalProfileRepository;
            _mapper = mapper;
        }

        public IOrganizationalProfileRepository OrganizationalProfileRepository { get => _OrganizationalProfileRepository; set => _OrganizationalProfileRepository = value; }

        public async Task<BaseCommandResponse> Handle(CreateOrganizationalProfileCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new OrganizationalProfileDtoValidator();
            var validationResult =await validator.ValidateAsync(request.OrganizationalProfileDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var organizationalProfile = _mapper.Map<OrganizationalProfiles>(request.OrganizationalProfileDto);
            organizationalProfile.Id = Guid.NewGuid();
            var data =await OrganizationalProfileRepository.Add(organizationalProfile);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
