using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Education.Request.Queries;
using ECX.HR.Application.DTOs.Education;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Education.Handler.Queries
{
    public class GetEducationListRequestHandler : IRequestHandler<GetEducationListRequest, List<EducationDto>>
    {
        private IEducationRepository _EducationRepository;
        private IMapper _mapper;
        public GetEducationListRequestHandler(IEducationRepository EducationRepository, IMapper mapper)
        {
            _EducationRepository= EducationRepository;
            _mapper = mapper;
        }
        public async Task<List<EducationDto>> Handle(GetEducationListRequest request, CancellationToken cancellationToken)
        {
            var Education =await _EducationRepository.GetAll();
            var activeEducation = Education.Where(education => education.Status == 0).ToList();
            return _mapper.Map<List<EducationDto>>(activeEducation);
        }
    }
}
