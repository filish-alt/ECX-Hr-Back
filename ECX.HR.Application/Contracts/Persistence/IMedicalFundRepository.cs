using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IMedicalFundRepository : IGenericRepository<MedicalFunds>
    {
		Task<List<MedicalFunds>> GetByEmpId(Guid empId);
		Task<List<MedicalFunds>> GetAllByStatus(string Status);
	}
}
