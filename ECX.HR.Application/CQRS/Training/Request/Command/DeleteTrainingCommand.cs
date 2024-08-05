using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Request.Command
{
    public class DeleteTrainingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
