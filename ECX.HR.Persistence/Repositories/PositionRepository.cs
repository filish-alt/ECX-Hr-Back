using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class PositionRepository : GenericRepository<Positions>, IPositionRepository
    {
        private readonly ECXHRDbContext _context;

        public PositionRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
