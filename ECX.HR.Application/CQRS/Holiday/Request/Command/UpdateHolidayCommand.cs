using ECX.HR.Application.DTOs.Holiday;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Request.Command
{
    public class UpdateHolidayCommand :IRequest<Unit>
    {
        public HolidayDto HolidayDto { get; set; }
    }
}
