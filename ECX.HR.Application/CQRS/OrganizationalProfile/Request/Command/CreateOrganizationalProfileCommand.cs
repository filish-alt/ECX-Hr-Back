using ECX.HR.Application.DTOs.OrganizationalProfile;
using ECX.HR.Application.DTOs.OrganizationalProfiles;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Request.Command
{
    public class CreateOrganizationalProfileCommand : IRequest<BaseCommandResponse>
    {
        public OrganizationalProfileDto OrganizationalProfileDto { get; set; }
    }
}
