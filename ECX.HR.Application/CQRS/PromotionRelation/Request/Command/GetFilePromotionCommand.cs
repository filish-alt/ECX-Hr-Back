using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Request.Command
{
    public class GetFilePromotionCommand : IRequest<byte[]>
    {
        public Guid VacancyId { get; }
        public Guid EmpId { get; }
        //public byte[] file {  get; }    
        public GetFilePromotionCommand(Guid vacid, Guid empid)
        {
            VacancyId = vacid;
            EmpId = empid;  
        }


    }
}
