using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface ILeaveBalanceRepository  : IGenericRepository<AnnualLeaveBalances> 
    {
        Task<List<AnnualLeaveBalances>> GetByEmpId(Guid id);
        Task<IEnumerable<AnnualLeaveBalances>> GetExpiredLeaveBalances();

    }
}
