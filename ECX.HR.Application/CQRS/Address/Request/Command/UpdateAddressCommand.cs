
using ECX.HR.Application.DTOs.Addresss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Addresss.Request.Command
{
    public class UpdateAddressCommand :IRequest<Unit>
    {
        public AddressDto AddressDto { get; set; }
    }
}
