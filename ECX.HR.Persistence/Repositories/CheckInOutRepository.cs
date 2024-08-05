using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class CheckInOutRepository : GenericRepository<CheckInOut>, ICheckInOutRepository
    {
        private readonly ECXHRDbContext _context;

        public CheckInOutRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CheckInOut>> GetCheckInOut( int user,DateTime? CHECKIN, DateTime? CHECKOUT)
        {


            return await _context.GetCheckInOutFromSourceDatabase(user, CHECKIN, CHECKOUT);

        }
    }
}
