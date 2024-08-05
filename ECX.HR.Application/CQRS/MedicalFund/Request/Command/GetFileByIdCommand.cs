using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Request.Command
{
    public class GetFileByIdCommand : IRequest<byte[]>
    {
        public Guid MedicalRequestId { set;  get; }
        //public byte[] file {  get; }    
        public GetFileByIdCommand(Guid fileId)
        {
            MedicalRequestId = fileId;
        }

    }
}
