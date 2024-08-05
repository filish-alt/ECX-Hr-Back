using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Leave
{
    public class LeaveTypeDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid leaveTypeId { get; set; }

        public string LeaveTypeName { get; set; }
        public int Maximum { get; set; }
        public int Status { get; set; }
    }
}
