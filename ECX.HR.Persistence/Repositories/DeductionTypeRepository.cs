using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class DeductionTypeRepository : GenericRepository<DeductionTypes>, IDeductionTypeRepository
    {
        private readonly ECXHRDbContext _context;

        public DeductionTypeRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
