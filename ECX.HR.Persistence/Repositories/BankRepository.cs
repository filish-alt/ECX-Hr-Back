using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class BankRepository : GenericRepository<Banks>, IBankRepository
    {
        private readonly ECXHRDbContext context;

        public BankRepository(ECXHRDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
