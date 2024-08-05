using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.WorkExperience.Request.Queries;

using ECX.HR.Application.DTOs.WorkExperiences;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.WorkExperience.Handler.Queries
{
    public class GetWorkExperienceDetailRequestHandler : IRequestHandler<GetWorkExperienceDetailRequest, List<WorkExperienceDto>>
    {
        private IWorkExperienceRepository _WorkExperienceRepository;
        private IMapper _mapper;
        public GetWorkExperienceDetailRequestHandler(IWorkExperienceRepository WorkExperienceRepository, IMapper mapper)
        {
            _WorkExperienceRepository = WorkExperienceRepository;
            _mapper = mapper;
        }
        public async Task<List<WorkExperienceDto>> Handle(GetWorkExperienceDetailRequest request, CancellationToken cancellationToken)
        {
            var workExperience =await _WorkExperienceRepository.GetByEmpId(request.EmpId);
            
            if (workExperience == null || !workExperience.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(workExperience), request.EmpId);

            else
                return _mapper.Map<List<WorkExperienceDto>>(workExperience);
        }
    }
}
