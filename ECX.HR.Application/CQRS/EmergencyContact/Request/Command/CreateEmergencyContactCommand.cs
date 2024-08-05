
using ECX.HR.Application.DTOs.EmergencyContacts;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmergencyContact.Request.Command
{
    public class CreateEmergencyContactCommand : IRequest<BaseCommandResponse>
    {
        public EmergencyContactDto EmergencyContactDto { get; set; }
    }
}
