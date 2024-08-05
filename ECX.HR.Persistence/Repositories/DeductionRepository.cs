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
    public class DeductionRepository : GenericRepository<Deductions>, IDeductionRepository
    {
        private readonly ECXHRDbContext _context;

        public DeductionRepository(ECXHRDbContext context) : base(context)
        {
        _context = context;
        }
        public async Task<List<Deductions>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Deductions>()
                     .Where(T => T.EmpId == empId && T.Status==0)
                .ToListAsync();
        }
    }
}
