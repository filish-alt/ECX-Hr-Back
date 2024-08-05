
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Models;
using ECX.HR.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class OtherLeaveBalanceRepository : GenericRepository<OtherLeaveBalances>, IOtherLeaveBalanceRepository
    {
        private readonly ECXHRDbContext _context;

        public OtherLeaveBalanceRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
     
        public async Task<List<OtherLeaveBalances>> GetByEmpId(Guid empId)
        {
            return await _context.Set<OtherLeaveBalances>()
                     .Where(T =>T.EmpId == empId && T.Status == 0)
                   .ToListAsync();
        }
        public async Task<IEnumerable<OtherLeaveBalances>> GetExpiredOtherLeaveBalances()
        {
            var currentDate = DateTime.Now;
            return await _context.OtherLeaveBalance
                .Where(OtherLeaveBalance => OtherLeaveBalance.EndDate < currentDate && OtherLeaveBalance.Status == 0)
                .ToListAsync();
        }
    }
}