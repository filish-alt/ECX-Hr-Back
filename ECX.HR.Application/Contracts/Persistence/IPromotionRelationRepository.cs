using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IPromotionRelationRepository : IGenericRepository<PromotionRelations>
    {
        Task<List<PromotionRelations>> GetByStatus(string PromotionStatus);
        
        Task<List<PromotionRelations>> GetByEmpId(Guid id);
        Task<PromotionRelations> GetByPosEmp(Guid vacancyId, Guid EmpId);
    }
}
