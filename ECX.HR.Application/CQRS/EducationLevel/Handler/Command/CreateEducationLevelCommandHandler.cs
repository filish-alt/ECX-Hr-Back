using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EducationLevel.Request.Command;

using ECX.HR.Application.DTOs.EducationLevels.Validators;
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

namespace ECX.HR.Application.CQRS.EducationLevel.Handler.Command
{
    public class CreateEducationLevelCommandHandler : IRequestHandler<CreateEducationLevelCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IEducationLevelRepository _EducationLevelRepository;
        private IMapper _mapper;
        public CreateEducationLevelCommandHandler(IEducationLevelRepository EducationLevelRepository, IMapper mapper)
        {
            _EducationLevelRepository = EducationLevelRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateEducationLevelCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new EducationLevelDtoValidator();
            var validationResult =await validator.ValidateAsync(request.EducationLevelDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var educationLevel = _mapper.Map<EducationLevels>(request.EducationLevelDto);
            educationLevel.Id = Guid.NewGuid();
            var data =await _EducationLevelRepository.Add(educationLevel);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
