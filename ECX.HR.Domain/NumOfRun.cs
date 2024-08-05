using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECX.HR.Domain
{
    public class NumOfRun
    {
        
        public int NUM_RUNID {  get; set; }
        public int OLDID { get; set; }
        public string NAME { get; set; }
        [Key]
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public short CYLE { get; set; }
        public short UNITS { get; set; }

    }
}
