using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.WorkExperience.Request.Queries;

using ECX.HR.Application.DTOs.WorkExperiences;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.WorkExperience.Handler.Queries
{
    public class GetWorkExperienceListRequestHandler : IRequestHandler<GetWorkExperienceListRequest, List<WorkExperienceDto>>
    {
        private IWorkExperienceRepository _WorkExperienceRepository;
        private IMapper _mapper;
        public GetWorkExperienceListRequestHandler(IWorkExperienceRepository WorkExperienceRepository, IMapper mapper)
        {
            _WorkExperienceRepository= WorkExperienceRepository;
            _mapper = mapper;
        }
        public async Task<List<WorkExperienceDto>> Handle(GetWorkExperienceListRequest request, CancellationToken cancellationToken)
        {
            var WorkExperience =await _WorkExperienceRepository.GetAll();
            var activeTraining = WorkExperience.Where(workExperience => workExperience.Status == 0).ToList();
            return _mapper.Map<List<WorkExperienceDto>>(activeTraining);
        }
    }
}
