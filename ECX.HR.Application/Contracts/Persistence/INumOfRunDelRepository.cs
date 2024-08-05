using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;

namespace ECXHR_Service.Controllers
{
    public interface INumOfRunDelRepository : IGenericRepository<NumRunDel>
    {
        Task<List<NumRunDel>> GetNumOfRunDel();
    }
}
