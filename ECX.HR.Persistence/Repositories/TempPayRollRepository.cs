using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class TempPayRollRepository : GenericRepository<TempPayrolls>, ITempPayrollRepository
    {
        private readonly ECXHRDbContext _context;

        public TempPayRollRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TempPayrolls>> GetByEmpId(Guid empId)
        {
            return await _context.Set<TempPayrolls>()
                     .Where(T => T.EmpId == empId && T.Status == 0)
                   .ToListAsync();

        }

    }
}
