using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequests>
    {
        Task<List<LeaveRequests>> GetByEmpId(Guid empId);
        Task<List<LeaveRequests>> GetAllLeave();

        Task<List<LeaveRequests>> GetByStatus(string leaveStatus, string supervisor);
        Task<List<LeaveRequests>> GetByEmpIdStatusDate(Guid empId,string leaveStatus,DateTime date);
        Task<List<LeaveRequests>> GetAllByStatus(string leaveStatus);

    }
}
