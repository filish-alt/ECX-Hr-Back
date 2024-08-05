using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Schedule
{
    public class NumOfRunDto
    {
      public  int NUM_RUNID { get; set; }
        public int OLDID { get; set; }
        public string NAME { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public short CYLE { get; set; }
        public short UNITS { get; set; }
    }
}
