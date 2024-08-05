
using ECX.HR.Application.ContractS.Persistence;
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
    public class PayrollContractRepository : GenericRepository<PayrollContracts>, IPayrollContractRepository
    {
        private readonly ECXHRDbContext _context;

        public PayrollContractRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
     
        public async Task<PayrollContracts> GetByEmpId(Guid empId)
        {
            return await _context.Set<PayrollContracts>()
                     .Where(T =>T.EmpId == empId && T.Status == 0)
                     .FirstOrDefaultAsync();
        }

    }
}