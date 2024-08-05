using ECX.HR.Application.DTOs.Holiday;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Request.Command
{
    public class CreateHolidayCommand : IRequest<BaseCommandResponse>
    {
        public HolidayDto HolidayDto { get; set; }
    }
}
