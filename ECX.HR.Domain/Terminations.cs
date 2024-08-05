using ECX.HR.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class Terminations :BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        
        public Guid Id { get; set; }
       
        [ForeignKey("Employees")]
        public Guid? EmpId { get; set; }
        [ForeignKey("Positions")]
        public Guid PositionId { get; set; }
        [ForeignKey("Levels")]
        public Guid LevelId { get; set; }
        public string TerminationType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string TerminationStatus { get; set; }
        public string Supervisor { get; set; }
        public int Status { get; set; }
        public virtual Employees Employees { get; set; }
        

    }
}
