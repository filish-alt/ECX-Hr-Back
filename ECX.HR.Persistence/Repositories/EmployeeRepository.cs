using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employees>, IEmployeeRepository
    {
        private readonly ECXHRDbContext _context;

        public EmployeeRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Employees>> GetByEcxId(string ecxId)
        {
            return await _context.Set<Employees>()
                     .Where(T => T.EcxId == ecxId)
                     .ToListAsync();
        }

        public async Task<List<Employees>> GetEmployeeDataAsync(Guid employeeid)
        {
            try
            {
                // Create a SqlParameter for the employeeId
                SqlParameter param = new SqlParameter("@EmployeeId", SqlDbType.UniqueIdentifier)
                {
                    Value = employeeid
                };

                // Call the stored procedure using FromSqlRaw
                var employeeData = await _context.Employee
                    .FromSqlRaw("EXEC GetEmployeeDatas @EmployeeId", param)
                    .ToListAsync();

                return employeeData;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                throw ex;
            }
        }

 

    }
}
