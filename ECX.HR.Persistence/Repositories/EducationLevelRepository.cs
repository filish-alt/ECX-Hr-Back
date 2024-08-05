using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class EducationLevelRepository : GenericRepository<EducationLevels>, IEducationLevelRepository
    {
        private readonly ECXHRDbContext _context;

        public EducationLevelRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
