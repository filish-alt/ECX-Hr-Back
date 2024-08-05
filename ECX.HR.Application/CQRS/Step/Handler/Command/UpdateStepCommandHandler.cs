using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Step.Request.Command;
using ECX.HR.Application.DTOs.Step.Validators;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Handler.Command
{
    public class UpdateStepCommandHandler : IRequestHandler<UpdateStepCommand, Unit>
    {
        private IStepRepository _StepRepository;
        private IMapper _mapper;
        public UpdateStepCommandHandler(IStepRepository StepRepository, IMapper mapper)
        {
            _StepRepository = StepRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStepCommand request, CancellationToken cancellationToken)
        {
            var validator = new StepDtoValidator();
            var validationResult = await validator.ValidateAsync(request.StepDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Step = await _StepRepository.GetById(request.StepDto.Id);
            _mapper.Map(request.StepDto, Step);
            await _StepRepository.Update(Step);
            return Unit.Value;
        }
    }
}
