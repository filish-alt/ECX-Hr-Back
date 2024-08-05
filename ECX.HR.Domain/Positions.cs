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
    public class Positions :BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
       
        public Guid PositionId { get; set; }
        [ForeignKey("Divisions")]
        public Guid DivisionId { get; set; }
     
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual Divisions Divisions { get; set; }
        
       
    }
}
