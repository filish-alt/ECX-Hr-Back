using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class BranchrRepository : GenericRepository<Branches>, IBranchRepository
    {
        private readonly ECXHRDbContext context;

        public BranchrRepository(ECXHRDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
