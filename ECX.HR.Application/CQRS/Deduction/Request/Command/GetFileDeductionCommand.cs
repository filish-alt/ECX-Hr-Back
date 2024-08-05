using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Request.Command
{
    public class GetFileDeductionCommand : IRequest<byte[]>
    {
        public Guid DeductionId { get; }
        //public byte[] file {  get; }    
        public GetFileDeductionCommand(Guid fileId)
        {
            DeductionId = fileId;
        }

    }
}