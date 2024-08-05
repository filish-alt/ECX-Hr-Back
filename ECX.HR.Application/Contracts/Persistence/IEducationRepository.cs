using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IEducationRepository : IGenericRepository<Educations>
    {
        Task<List<Educations>> GetByEmpId(Guid id);
    }
}
