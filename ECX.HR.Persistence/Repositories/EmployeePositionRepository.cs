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
    public class EmployeePositionRepository : GenericRepository<EmployeePositions>, IEmployeePositionRepository
    {
        private readonly ECXHRDbContext _context;

        public EmployeePositionRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }

        public async Task<EmployeePositions> GetByEmpId(Guid empId)
        {
            return await _context.Set<EmployeePositions>()
                     .Where(T => T.EmpId == empId && T.Status == 0)
                     .FirstOrDefaultAsync();
        }
    }
}
