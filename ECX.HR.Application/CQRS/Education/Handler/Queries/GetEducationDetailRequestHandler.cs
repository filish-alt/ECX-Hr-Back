using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Education.Request.Queries;
using ECX.HR.Application.DTOs.Division;
using ECX.HR.Application.DTOs.Education;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Education.Handler.Queries
{
    public class GetEducationDetailRequestHandler : IRequestHandler<GetEducationDetailRequest, List<EducationDto>>
    {
        private IEducationRepository _EducationRepository;
        private IMapper _mapper;
        public GetEducationDetailRequestHandler(IEducationRepository EducationRepository, IMapper mapper)
        {
            _EducationRepository = EducationRepository;
            _mapper = mapper;
        }
        public async Task<List<EducationDto>> Handle(GetEducationDetailRequest request, CancellationToken cancellationToken)
        {
            var education =await _EducationRepository.GetByEmpId(request.EmpId);
           
            if (education == null || !education.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(education), request.EmpId);

            else
                return _mapper.Map<List<EducationDto>>(education);
        }
    }
}
