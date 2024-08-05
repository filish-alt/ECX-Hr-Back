using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.WorkExperience.Request.Command;

using ECX.HR.Application.DTOs.WorkExperiences.Validator;
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

namespace ECX.HR.Application.CQRS.WorkExperience.Handler.Command
{
    public class CreateWorkExperienceCommandHandler : IRequestHandler<CreateWorkExperienceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IWorkExperienceRepository _WorkExperienceRepository;
        private IMapper _mapper;
        public CreateWorkExperienceCommandHandler(IWorkExperienceRepository WorkExperienceRepository, IMapper mapper)
        {
            _WorkExperienceRepository = WorkExperienceRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new WorkExperienceDtoValidator();
            var validationResult =await validator.ValidateAsync(request.WorkExperienceDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var workExperience = _mapper.Map<WorkExperiences>(request.WorkExperienceDto);
            workExperience.Id = Guid.NewGuid();
            var data =await _WorkExperienceRepository.Add(workExperience);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
