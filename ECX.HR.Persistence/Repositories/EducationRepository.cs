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
    public class EducationRepository : GenericRepository<Educations>, IEducationRepository
    {
        private readonly ECXHRDbContext _context;

        public EducationRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }

      /*  public async Task<List<Educations>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Educations>()
         .Where(T => T.EmpId == empId)
         .FirstOrDefaultAsync();
        }*/

        public async Task<List<Educations>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Educations>()
                .Where(education => education.EmpId == empId && education.Status == 0)
                .ToListAsync();
        }

    }
}
