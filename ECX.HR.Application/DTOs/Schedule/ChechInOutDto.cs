using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Schedule
{
    public class ChechInOutDto
    {
        public int USERID { get; set; }
        public DateTime? CHECKTIME { get; set; }
        public string CHECKTYPE { get; set; }
        public int? VERIFYCODE { get; set; }
        public string SENSORID { get; set; }
        public string Memoinfo { get; set; }
        public string WorkCode { get; set; }
        public string sn { get; set; }
        public short UserExtFmt { get; set; }
    }
}
