using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Request.Command
{
    public class DeleteSpouseCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
