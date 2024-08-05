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
    public class MedicalBalanceRepository : GenericRepository<MedicalBalances>, IMedicalBalanceRepository
    {
        private readonly ECXHRDbContext _context;

        public MedicalBalanceRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }

        public async Task<List<MedicalBalances>> GetByEmpId(Guid empId)
        {
            DateTime currentDate = DateTime.Now;
            return await _context.Set<MedicalBalances>()
                .Where(T => T.EmpId == empId && T.Status == 0)
                   .ToListAsync();
        }
    }
}
