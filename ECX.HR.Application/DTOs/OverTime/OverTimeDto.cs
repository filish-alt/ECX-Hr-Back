using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.OverTime
{
    public class OverTimeDto : BaseDtos
    {

        public int PId { get; set; }
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public DateTime Date { get; set; }
        public double OTDay { get; set; }
        public double OTNight { get; set; }
        public double OTWeekend { get; set; }
        public double OTHoliday { get; set; }
        public int Status { get; set; }
    }
}
