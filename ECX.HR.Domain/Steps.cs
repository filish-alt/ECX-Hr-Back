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
    public class Steps : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        [ForeignKey("SalaryTypes")]
        public Guid? SalaryTypeId { get; set; }
        [ForeignKey("Levels")]
        public Guid? LevelId { get; set; }
        public int Status { get; set; }

        public virtual Levels Levels { get; set; }
        
    }
}
