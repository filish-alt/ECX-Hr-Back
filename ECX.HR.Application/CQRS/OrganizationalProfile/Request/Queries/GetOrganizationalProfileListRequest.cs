using ECX.HR.Application.DTOs.OrganizationalProfile;
using ECX.HR.Application.DTOs.OrganizationalProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Request.Queries
{
    public class GetOrganizationalProfileListRequest :IRequest<List<OrganizationalProfileDto>>
    {
       
    }
}
