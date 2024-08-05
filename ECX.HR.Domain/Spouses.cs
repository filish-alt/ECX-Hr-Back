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
    public class Spouses :BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        
        public Guid Id { get; set; }
       
        [ForeignKey("Employees")]
        public Guid? EmpId { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relationship { get; set; }
        public int Status { get; set; }
        public virtual Employees Employees { get; set; }
        

    }
}
