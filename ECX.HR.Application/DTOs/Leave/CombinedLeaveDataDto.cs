using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.LeaveBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Leave
{
    public class CombinedLeaveDataDto
    {
        public EmployeeDto Employee { get; set; }
        public List<LeaveRequestDto> LeaveRequests { get; set; }
        public List<AnnualLeaveBalanceDto> AnnualLeaveBalances { get; set; }
        public List<OtherLeaveBalanceDto> OtherLeaveBalances { get; set; }
    }
}
