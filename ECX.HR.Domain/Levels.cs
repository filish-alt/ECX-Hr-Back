using ECX.HR.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECX.HR.Domain
{
    public class Levels : BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        
        public Guid LevelId { get; set; }
        [ForeignKey("Positions")]
        public Guid? PositionId { get; set; }         
        public string Description { get; set; }
        public int Status { get; set; }

        public ICollection<Steps> Steps { get; set;}
        
    }
}
