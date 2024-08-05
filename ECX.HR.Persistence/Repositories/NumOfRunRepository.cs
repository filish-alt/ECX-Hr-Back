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
    public class NumOfRunRepository : GenericRepository<NumOfRun>, INumRunRepository
    {
        private readonly ECXHRDbContext _context;

        public NumOfRunRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<NumOfRun>> GetNumOfRun()
        {
            return await _context.GetNumOfRunDataFromSourceDatabase();

        }
    }
}
