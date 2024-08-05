using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.Models;
using ECX.HR.Domain;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class AttRepository : GenericRepository<NumOfRun>, IAttRepository
    {
		private readonly ECXHRDbContextAttendance _contextAttenda;

		public AttRepository(ECXHRDbContextAttendance contextAttenda) :base()
        {
			_contextAttenda = contextAttenda;
		}

		public async Task<List<NumOfRun>> GetNumOfRunDataFromSourceDatabase()
		{
			return await _contextAttenda.Set<NumOfRun>()
			  .ToListAsync();

		}
        public async Task<List<USERINFO>> GetUserInfoDataFromSourceDatabase()
        {
            return await _contextAttenda.Set<USERINFO>()
              .ToListAsync();

        }
        public async Task<List<NumRunDel>> GetNumRunDelDataFromSourceDatabase()
        {
            return await _contextAttenda.Set<NumRunDel>()
              .ToListAsync();

        }
        public async Task<List<UserOfNum>> GetUserOfNumFromSourceDatabase(int UserId)
        {
            return await _contextAttenda.Set<UserOfNum>().Where(T=>T.USERID== UserId)
              .ToListAsync();

        }

        public async Task<List<SchClass>> GetTable1DataFromSourceDatabase()
        {
            return await _contextAttenda.Set<SchClass>()
              .ToListAsync();

        }
   

        public async Task<List<CheckInOut>> GetCheckInOutFromSourceDatabase(int userId, DateTime start,DateTime end)
        {
            return await _contextAttenda.Set<CheckInOut>().Where(T=>T.CHECKTIME>= start && T.CHECKTIME <= end && T.USERID==userId)
              .ToListAsync();

        }
        public async Task<List<CheckInOut>> GetChechInOutByDate(DateTime? date)
        {
            return await _contextAttenda.Set<CheckInOut>().Where(T =>  T.CHECKTIME >= date)
              .ToListAsync();

        }





    }

}