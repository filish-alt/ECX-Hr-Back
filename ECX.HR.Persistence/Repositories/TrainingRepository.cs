using ECX.HR.Application.Contracts.Persistence;
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
    public class TrainingRepository : GenericRepository<Trainings>, ITrainingRepository
    {
        private readonly ECXHRDbContext _context;

        public TrainingRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Trainings>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Trainings>()
                   .Where(T => T.EmpId == empId && T.Status == 0)
                   .ToListAsync();
        }
    }
}
