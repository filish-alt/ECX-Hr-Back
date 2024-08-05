using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Queries;
using ECX.HR.Application.DTOs.OrganizationalProfile;
using ECX.HR.Application.DTOs.OrganizationalProfiles;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Handler.Queries
{
    public class GetOrganizationalProfileListRequestHandler : IRequestHandler<GetOrganizationalProfileListRequest, List<OrganizationalProfileDto>>
    {
        private IOrganizationalProfileRepository _OrganizationalProfileRepository;
        private IMapper _mapper;
        public GetOrganizationalProfileListRequestHandler(IOrganizationalProfileRepository OrganizationalProfileRepository, IMapper mapper)
        {
            _OrganizationalProfileRepository= OrganizationalProfileRepository;
            _mapper = mapper;
        }
        public async Task<List<OrganizationalProfileDto>> Handle(GetOrganizationalProfileListRequest request, CancellationToken cancellationToken)
        {
            var organizationalProfile =await _OrganizationalProfileRepository.GetAll();
            return _mapper.Map<List<OrganizationalProfileDto>>(organizationalProfile);
        }
    }
}
