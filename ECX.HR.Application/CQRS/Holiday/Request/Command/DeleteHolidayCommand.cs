using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Request.Command
{
    public class DeleteHolidayCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
