using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IOtherLeaveBalanceRepository  : IGenericRepository<OtherLeaveBalances> 
    {
        Task<List<OtherLeaveBalances>> GetByEmpId(Guid id);
        Task<IEnumerable<OtherLeaveBalances>> GetExpiredOtherLeaveBalances();

    }
}
