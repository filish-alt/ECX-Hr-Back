
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
    public class LeaveBalanceRepository : GenericRepository<AnnualLeaveBalances>, ILeaveBalanceRepository
    {
        private readonly ECXHRDbContext _context;

        public LeaveBalanceRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
     
        public async Task<List<AnnualLeaveBalances>> GetByEmpId(Guid empId)
        {
            return await _context.Set<AnnualLeaveBalances>()
                     .Where(T =>T.EmpId == empId && T.Status == 0)
                   .ToListAsync();
        }
        public async Task<IEnumerable<AnnualLeaveBalances>> GetExpiredLeaveBalances()
        {
            var currentDate = DateTime.Now;
            var leaveBalances = await _context.AnnualLeaveBalances
        .Where(leaveBalance => leaveBalance.EndDate < currentDate && leaveBalance.Status == 0)
        .ToListAsync();

            return leaveBalances;
        }

    }
}