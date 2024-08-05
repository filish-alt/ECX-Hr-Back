using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Request.Command
{
    public class GetFileRequestCommand : IRequest<byte[]>
    {
        public Guid LeaveRequestId { get; }
        //public byte[] file {  get; }    
        public GetFileRequestCommand(Guid fileId)
        {
            LeaveRequestId = fileId;
        }

    }
}
