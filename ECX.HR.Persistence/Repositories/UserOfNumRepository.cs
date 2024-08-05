using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using ECXHR_Service.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class UserOfNumRepository : GenericRepository<UserOfNum>, IUserOfNumRepository
    {
        private readonly ECXHRDbContextAttendance _contextAttenda;

        public UserOfNumRepository(ECXHRDbContextAttendance contextAttenda) : base()
        {
            _contextAttenda = contextAttenda;
        }

        public async Task<List<UserOfNum>> GetUserOfNum(int USERID)
        {
            return await _contextAttenda.Set<UserOfNum>()
              .ToListAsync();

        }
    }

}
