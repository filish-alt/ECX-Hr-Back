using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Schedule
{
    public class UserOfNumDto
    {
        public int USERID { get; set; }
        public int NUM_OF_RUN_ID { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public int ISNOTOF_RUN { get; set; }
        public int ORDER_RUN { get; set; }
    }
}
