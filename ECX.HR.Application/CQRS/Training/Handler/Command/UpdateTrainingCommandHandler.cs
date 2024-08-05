using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Training.Request.Command;
using ECX.HR.Application.DTOs.Trainings.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Handler.Command
{
    public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, Unit>
    {
        private ITrainingRepository _TrainingRepository;
        private IMapper _mapper;
        public UpdateTrainingCommandHandler(ITrainingRepository TrainingRepository, IMapper mapper)
        {
            _TrainingRepository = TrainingRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
        {
            var validator = new TrainingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TrainingDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Training = await _TrainingRepository.GetById(request.TrainingDto.Id);
            _mapper.Map(request.TrainingDto, Training);
            await _TrainingRepository.Update(Training);
            return Unit.Value;
        }
    }
}
