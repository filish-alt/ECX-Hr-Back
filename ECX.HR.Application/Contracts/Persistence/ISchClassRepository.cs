using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;

namespace ECXHR_Service.Controllers
{
    public interface ISchClassRepository : IGenericRepository<SchClass>
    {
        Task<List<SchClass>> GetSch();
    }
}
