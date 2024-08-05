using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Queries;
using ECX.HR.Application.DTOs.Levels;
using ECX.HR.Application.DTOs.OrganizationalProfile;
using ECX.HR.Application.DTOs.OrganizationalProfiles;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Handler.Queries
{
    public class GetOrganizationalProfileDetailRequestHandler : IRequestHandler<GetOrganizationalProfileDetailRequest, OrganizationalProfileDto>
    {
        private IOrganizationalProfileRepository _OrganizationalProfileRepository;
        private IMapper _mapper;
        public GetOrganizationalProfileDetailRequestHandler(IOrganizationalProfileRepository OrganizationalProfileRepository, IMapper mapper)
        {
            _OrganizationalProfileRepository = OrganizationalProfileRepository;
            _mapper = mapper;
        }
        public async Task<OrganizationalProfileDto> Handle(GetOrganizationalProfileDetailRequest request, CancellationToken cancellationToken)
        {
            var organizationalProfile =await _OrganizationalProfileRepository.GetById(request.Id);
           
            if (organizationalProfile == null)
                throw new NotFoundException(nameof(organizationalProfile), request.Id);

            else
                return _mapper.Map<OrganizationalProfileDto>(organizationalProfile);
        }
    }
}
