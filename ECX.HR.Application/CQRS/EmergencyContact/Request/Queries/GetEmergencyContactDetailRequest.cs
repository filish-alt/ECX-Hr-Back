
using ECX.HR.Application.DTOs.EmergencyContacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmergencyContact.Request.Queries
{
    public class GetEmergencyContactDetailRequest :IRequest<List<EmergencyContactDto>>
    {
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }


       
    }
}
