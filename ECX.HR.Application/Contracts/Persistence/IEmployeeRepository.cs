using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IGenericRepository<Employees>
    {
        Task<List<Employees>> GetByEcxId(string id);

        Task<List<Employees>> GetEmployeeDataAsync(Guid employeeid);
    }
}
