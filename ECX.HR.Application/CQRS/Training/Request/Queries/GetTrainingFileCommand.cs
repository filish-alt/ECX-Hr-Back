using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Request.Queries
{
    public class GetTrainingFileCommand : IRequest<byte[]>
    {
        public Guid Id { get; }
        //public byte[] file {  get; }    
        public GetTrainingFileCommand(Guid fileId)
        {
            Id = fileId;
        }

    }
}
