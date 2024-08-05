using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class ContractEmployeeRepository : GenericRepository<ContractEmployees>, IContractEmployeesRegstration
    {
        private readonly ECXHRDbContext _context;
        public ContractEmployeeRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
