using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Request.Command
{
    public class GetFileOutsourceCommand : IRequest<byte[]>
    {
        public Guid Outsourceid { get; }
        //public byte[] file {  get; }    
        public GetFileOutsourceCommand(Guid fileId)
        {
            Outsourceid = fileId;
        }

    }
}
