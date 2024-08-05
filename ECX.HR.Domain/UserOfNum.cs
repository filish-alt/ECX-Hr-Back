using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class UserOfNum
    {

       public int USERID { get; set; }

       public int NUM_OF_RUN_ID { get; set; }
       public DateTime STARTDATE { get; set; }
       public DateTime ENDDATE { get; set; }
       public int ISNOTOF_RUN { get; set; }       
       public int? ORDER_RUN { get; set; }

    }
}
