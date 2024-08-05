using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EducationLevel.Request.Command;

using ECX.HR.Application.DTOs.EducationLevels.Validators;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EducationLevel.Handler.Command
{
    public class UpdateEducationLevelCommandHandler : IRequestHandler<UpdateEducationLevelCommand, Unit>
    {
        private IEducationLevelRepository _EducationLevelRepository;
        private IMapper _mapper;
        public UpdateEducationLevelCommandHandler(IEducationLevelRepository EducationLevelRepository, IMapper mapper)
        {
            _EducationLevelRepository = EducationLevelRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var validator = new EducationLevelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EducationLevelDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var EducationLevel = await _EducationLevelRepository.GetById(request.EducationLevelDto.Id);
            _mapper.Map(request.EducationLevelDto, EducationLevel);
            await _EducationLevelRepository.Update(EducationLevel);
            return Unit.Value;
        }
    }
}
