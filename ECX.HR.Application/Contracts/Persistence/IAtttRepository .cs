using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IAttRepository : IGenericRepository<NumOfRun>
    {
        Task<List<NumOfRun>> GetNumOfRunDataFromSourceDatabase();
        Task<List<USERINFO>> GetUserInfoDataFromSourceDatabase();
        Task<List<NumRunDel>> GetNumRunDelDataFromSourceDatabase();
        Task<List<UserOfNum>> GetUserOfNumFromSourceDatabase(int UserId);
        Task<List<SchClass>> GetTable1DataFromSourceDatabase();
        Task<List<CheckInOut>> GetCheckInOutFromSourceDatabase(int userId, DateTime start, DateTime end);
        Task<List<CheckInOut>> GetChechInOutByDate(DateTime? date);

    }
}
