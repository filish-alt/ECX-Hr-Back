using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Step.Request.Command;
using ECX.HR.Application.DTOs.Step;
using ECX.HR.Application.DTOs.Step.Validators;
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

namespace ECX.HR.Application.CQRS.Step.Handler.Command
{
    public class CreateStepCommandHandler : IRequestHandler<CreateStepCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IStepRepository _StepRepository;
        private IMapper _mapper;
        public CreateStepCommandHandler(IStepRepository StepRepository, IMapper mapper)
        {
            _StepRepository = StepRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateStepCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new StepDtoValidator();
            var validationResult =await validator.ValidateAsync(request.StepDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var step = _mapper.Map<Steps>(request.StepDto);
            step.Id = Guid.NewGuid();
            var data =await _StepRepository.Add(step);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
