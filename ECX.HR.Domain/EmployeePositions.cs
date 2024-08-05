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
    public  class EmployeePositions : BaseDomainEntity
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        
        public Guid Id { get; set; }
        [ForeignKey("Employees")]
        public Guid? EmpId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid StepId { get; set; }
        public Guid BranchId { get; set; }
        public Guid position { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set;}
        public int Status {get; set; }

    }
}
