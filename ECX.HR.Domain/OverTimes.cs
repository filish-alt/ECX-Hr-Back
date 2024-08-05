using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Domain.Common;

namespace ECX.HR.Domain
{
    public class OverTimes : BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }

        [Key]

        public Guid Id { get; set; }
        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
        public DateTime Date { get; set; }
        public double OTDay { get; set; }
        public double OTNight { get; set; }
        public double OTWeekend { get; set; }
        public double OTHoliday { get; set; }
        public int Status { get; set; }

    }
}
