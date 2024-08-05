using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Education.Request.Command;
using ECX.HR.Application.DTOs.Education.Validator;

using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Education.Handler.Command
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, Unit>
    {
        private IEducationRepository _EducationRepository;
        private IMapper _mapper;
        public UpdateEducationCommandHandler(IEducationRepository EducationRepository, IMapper mapper)
        {
            _EducationRepository = EducationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var validator = new EducationValidator();
            var validationResult = await validator.ValidateAsync(request.EducationDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Education = await _EducationRepository.GetById(request.EducationDto.Id);
            _mapper.Map(request.EducationDto, Education);
            await _EducationRepository.Update(Education);
            return Unit.Value;
        }
    }
}
