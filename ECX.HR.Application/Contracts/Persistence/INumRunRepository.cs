using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface INumRunRepository : IGenericRepository<NumOfRun>
    {
        Task<List<NumOfRun>> GetNumOfRun();

    }
}
