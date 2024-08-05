using ECX.HR.Application.DTOs.Holiday;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Request.Queries
{
    public class GetHolidayDetailRequest :IRequest<HolidayDto>
    {
        public Guid Id { get; set; }
    }
}
