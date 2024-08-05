using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Command
{
    public class GetEducationFileCommand : IRequest<byte[]>
    {
        public Guid Id { get; }
        //public byte[] file {  get; }    
        public GetEducationFileCommand(Guid fileId)
        {
           Id = fileId;
        }

    }
}
