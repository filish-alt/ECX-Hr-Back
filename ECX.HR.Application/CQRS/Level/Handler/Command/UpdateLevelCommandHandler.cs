using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Level.Request.Command;
using ECX.HR.Application.DTOs.Levels.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Level.Handler.Command
{
    public class UpdateLevelCommandHandler : IRequestHandler<UpdateLevelCommand, Unit>
    {
        private ILevelRepository _LevelRepository;
        private IMapper _mapper;
        public UpdateLevelCommandHandler(ILevelRepository LevelRepository, IMapper mapper)
        {
            _LevelRepository = LevelRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
        {
            var validator = new LevelDtoValidators();
            var validationResult = await validator.ValidateAsync(request.LevelDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Level = await _LevelRepository.GetById(request.LevelDto.LevelId);
            _mapper.Map(request.LevelDto, Level);
            await _LevelRepository.Update(Level);
            return Unit.Value;
        }
    }
}
