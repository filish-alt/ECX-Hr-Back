using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.WorkExperience.Request.Command;

using ECX.HR.Application.DTOs.WorkExperiences.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.WorkExperience.Handler.Command
{
    public class UpdateWorkExperienceCommandHandler : IRequestHandler<UpdateWorkExperienceCommand, Unit>
    {
        private IWorkExperienceRepository _WorkExperienceRepository;
        private IMapper _mapper;
        public UpdateWorkExperienceCommandHandler(IWorkExperienceRepository WorkExperienceRepository, IMapper mapper)
        {
            _WorkExperienceRepository = WorkExperienceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var validator = new WorkExperienceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.WorkExperienceDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var WorkExperience = await _WorkExperienceRepository.GetById(request.WorkExperienceDto.Id);
            _mapper.Map(request.WorkExperienceDto, WorkExperience);
            await _WorkExperienceRepository.Update(WorkExperience);
            return Unit.Value;
        }
    }
}
