using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.WorkExperience.Request.Command
{
    public class GetWorkExperienceFileCommand : IRequest<byte[]>
    {
        public Guid Id { get; }
        //public byte[] file {  get; }    
        public GetWorkExperienceFileCommand(Guid fileId)
        {
            Id = fileId;
        }

    }
}
