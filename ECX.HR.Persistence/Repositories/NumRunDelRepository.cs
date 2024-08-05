using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using ECXHR_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class NumRunDelRepository : GenericRepository<NumRunDel>, INumOfRunDelRepository
    {
        private readonly ECXHRDbContext _context;

        public NumRunDelRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<NumRunDel>> GetNumOfRunDel()
        {
            return await _context.GetNumRunDelDataFromSourceDatabase();

        }
    }
}
