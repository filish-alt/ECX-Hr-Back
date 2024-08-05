using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class SchClass
    {
        [Key]
       public int schClassid { get; set; }
        public string schName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LateMinutes { get; set; }
        public int EarlyMinutes { get; set;}
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }   
        public int Color { get; set; }
        public short AutoBind { get; set; }
        public DateTime CheckInTime1 { get; set; }
        public DateTime CheckInTime2 { get; set; }
        public DateTime CheckOutTime1 { get; set; }
        public DateTime CheckOutTime2 { get;set; }
        public double WorkDay { get; set; }
        public string SensorID { get; set; } 
        public double WorkMins { get; set; }
        public byte[] upsize_ts { get; set; }
    }
}
