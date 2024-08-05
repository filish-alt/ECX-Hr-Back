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
    public class Allowances :BaseDomainEntity
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int PId { get; set; }
        [Key]
       
        public Guid Id { get; set; }
        public Guid AllowanceType { get; set; }
        public Guid Position { get; set; }
        public Guid Grade { get; set; }
        public Guid Step { get; set; }
        public double Amount { get; set; }
        public double RatePercent { get; set; }
        public int Rate { get; set; }
        public int Status { get; set; }
    }
}
