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
    public class AllowanceRepository : GenericRepository<Allowances>, IAllwoanceRepository
    {
        private readonly ECXHRDbContext _context;

        public AllowanceRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Allowances>> GetByPosId(Guid postionid, Guid step)
        {
            return await _context.Set<Allowances>()
                     .Where(T => T.Position == postionid  && T.Step == step && T.Status == 0)
                .ToListAsync();
        }

       
    }
}
