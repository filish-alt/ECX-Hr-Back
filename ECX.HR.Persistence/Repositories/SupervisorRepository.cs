
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class SupervisorRepository : GenericRepository<Supervisors>, ISupervisiorRepository
    {
        private readonly ECXHRDbContext _context;

        public SupervisorRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
