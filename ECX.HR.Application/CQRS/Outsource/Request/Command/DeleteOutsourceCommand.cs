using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Request.Command
{
    public class DeleteOutsourceCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
