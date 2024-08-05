using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Position.Request.Command;
using ECX.HR.Application.DTOs.Positions.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Position.Handler.Command
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Unit>
    {
        private IPositionRepository _PositionRepository;
        private IMapper _mapper;
        public UpdatePositionCommandHandler(IPositionRepository PositionRepository, IMapper mapper)
        {
            _PositionRepository = PositionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var validator = new PositionDtoValidators();
            var validationResult = await validator.ValidateAsync(request.PositionDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Position = await _PositionRepository.GetById(request.PositionDto.PositionId);
            _mapper.Map(request.PositionDto, Position);
            await _PositionRepository.Update(Position);
            return Unit.Value;
        }
    }
}
