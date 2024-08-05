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
    public class MedicalFundRepository : GenericRepository<MedicalFunds>, IMedicalFundRepository
    {
        private readonly ECXHRDbContext _context;

        public MedicalFundRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MedicalFunds>> GetByEmpId(Guid empId)
        {
            DateTime currentDate = DateTime.Now;
            return await _context.Set<MedicalFunds>()
                .Where(T => T.EmpId == empId && T.Status == 0)
                   .ToListAsync();
        }
        public async Task<List<MedicalFunds>> GetAllByStatus(string status)
        {
            DateTime currentDate = DateTime.Now;
            return await _context.Set<MedicalFunds>()
                     .Where(T => T.ApprovalStatus == status && T.Date.Year >= currentDate.Year - 1 && T.Status == 0)
                   .ToListAsync();
        }

       
    }
}