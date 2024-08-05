using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
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
    public class AdressRepository : GenericRepository<Adress>, IAdressRepository
    {
        private readonly ECXHRDbContext _context;

        public AdressRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
     
        public async Task<Adress> GetByEmpId(Guid? empId)
        {
            return await _context.Set<Adress>()
                     .Where(T =>T.EmpId == empId && T.Status == 0)
                     .FirstOrDefaultAsync();
        }

    }
}