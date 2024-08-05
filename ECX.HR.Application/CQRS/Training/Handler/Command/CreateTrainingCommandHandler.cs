using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Training.Request.Command;
using ECX.HR.Application.DTOs.Trainings.Validator;
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

namespace ECX.HR.Application.CQRS.Training.Handler.Command
{
    public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ITrainingRepository _TrainingRepository;
        private IMapper _mapper;
        public CreateTrainingCommandHandler(ITrainingRepository TrainingRepository, IMapper mapper)
        {
            _TrainingRepository = TrainingRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new TrainingDtoValidator();
            var validationResult =await validator.ValidateAsync(request.TrainingDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var training = _mapper.Map<Trainings>(request.TrainingDto);
            training.Id = Guid.NewGuid();
            var data =await _TrainingRepository.Add(training);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
