using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EducationLevel.Request.Queries;

using ECX.HR.Application.DTOs.EducationLevels;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EducationLevel.Handler.Queries
{
    public class GetEducationLevelDetailRequestHandler : IRequestHandler<GetEducationLevelDetailRequest, EducationLevelDto>
    {
        private IEducationLevelRepository _EducationLevelRepository;
        private IMapper _mapper;
        public GetEducationLevelDetailRequestHandler(IEducationLevelRepository EducationLevelRepository, IMapper mapper)
        {
            _EducationLevelRepository = EducationLevelRepository;
            _mapper = mapper;
        }
        public async Task<EducationLevelDto> Handle(GetEducationLevelDetailRequest request, CancellationToken cancellationToken)
        {
            var educationLevel =await _EducationLevelRepository.GetById(request.Id);
            
            if (educationLevel == null || educationLevel.Status != 0)
                throw new NotFoundException(nameof(educationLevel), request.Id);

            else
                return _mapper.Map<EducationLevelDto>(educationLevel);
        }
    }
}
