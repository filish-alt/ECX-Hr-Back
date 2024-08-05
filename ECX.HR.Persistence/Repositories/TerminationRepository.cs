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
    public class TerminationRepository : GenericRepository<Terminations>, ITerminationRepository
    {
        private readonly ECXHRDbContext _context;

        public TerminationRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Terminations>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Terminations>()
                     .Where(T => T.EmpId == empId && T.Status == 0)
                  .ToListAsync();

        }
    }
}
