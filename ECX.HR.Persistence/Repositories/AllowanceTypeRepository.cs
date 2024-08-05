using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.DTOs.Allowances.cs;
using ECX.HR.Application.DTOs.AllowanceType;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class AllowanceTypeRepository : GenericRepository<AllowanceTypes>, IAllowanceTypeRepository
    {
        private readonly ECXHRDbContext _context;

        public AllowanceTypeRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
