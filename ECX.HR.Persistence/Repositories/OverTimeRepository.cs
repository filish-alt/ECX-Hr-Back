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
    public class OverTimeRepository : GenericRepository<OverTimes>, IOverTimeRepository
    {
        private readonly ECXHRDbContext _context;

        public OverTimeRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OverTimes> GetByEmpId(Guid empId)
        {
            return await _context.Set<OverTimes>()
                     .Where(T => T.EmpId == empId && T.Status == 0)
                   .FirstAsync();
        }
       
    }
}
