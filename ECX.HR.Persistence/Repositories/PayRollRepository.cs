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
    public class PayRollRepository : GenericRepository<Payrolls>, IPayrollRepository
    {
        private readonly ECXHRDbContext _context;

        public PayRollRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Payrolls>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Payrolls>()
                     .Where(T => T.EmpId == empId && T.Status == 0)
                   .ToListAsync();

        }

    }
}
