using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Schedule
{
    public class NumRunDelDto
    {
        public short NUM_RUNID { get; set; }
        public DateTime STARTTIME { get; set; }
        public DateTime ENDTIME { get; set; }
        public short SDAYS { get; set; }
        public short EDAYS { get; set; }
        public int SCHCLASSID { get; set; }
        public int OverTime { get; set; }
    }
}
