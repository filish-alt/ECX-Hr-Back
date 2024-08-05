using AutoMapper;
using ECX.HR.Application.CQRS.WorkExperience.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.WorkExperience.Handler.Command
{
    public class DeleteWorkExperienceCommandHandler : IRequestHandler<DeleteWorkExperienceCommand>
    {
        private IWorkExperienceRepository _WorkExperienceRepository;
        private IMapper _mapper;
        public DeleteWorkExperienceCommandHandler(IWorkExperienceRepository WorkExperienceRepository, IMapper mapper)
        {
            _WorkExperienceRepository = WorkExperienceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var WorkExperience = await _WorkExperienceRepository.GetById(request.Id);
            WorkExperience.Status = 1;
            await _WorkExperienceRepository.Update(WorkExperience);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteWorkExperienceCommand>.Handle(DeleteWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var WorkExperience = await _WorkExperienceRepository.GetById(request.Id);
            if(WorkExperience == null) 
                throw new NotFoundException(nameof(WorkExperience), request.Id);
            WorkExperience.Status = 1;
            await _WorkExperienceRepository.Update(WorkExperience);
        }
    }
}
