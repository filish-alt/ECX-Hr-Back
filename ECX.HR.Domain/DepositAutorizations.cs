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
    public class DepositAutorizations :BaseDomainEntity
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
       
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Employees")]
        public Guid? EmpId { get; set; }
        [ForeignKey("Bank")]

        public Guid BankId { get; set; }
        public string BankBranch { get; set;}
        public long BankAccount { get; set; }
        public string TinNumber { get; set; }
        public int Status { get; set; }

    }
}
