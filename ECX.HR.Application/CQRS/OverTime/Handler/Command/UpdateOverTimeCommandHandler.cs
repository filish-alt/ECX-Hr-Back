using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.OverTime.Request.Command;
using ECX.HR.Application.DTOs.OverTime.Validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Handler.Command
{
    public class UpdateOverTimeCommandHandler : IRequestHandler<UpdateOverTimeCommand, Unit>
    {
        private IOverTimeRepository _OverTimeRepository;
        private IMapper _mapper;
        public UpdateOverTimeCommandHandler(IOverTimeRepository OverTimeRepository, IMapper mapper)
        {
            _OverTimeRepository = OverTimeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOverTimeCommand request, CancellationToken cancellationToken)
        {
            var validator = new OverTimeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OverTimeDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var OverTime = await _OverTimeRepository.GetById(request.OverTimeDto.Id);
            _mapper.Map(request.OverTimeDto, OverTime);
            await _OverTimeRepository.Update(OverTime);
            return Unit.Value;
        }
    }
}
