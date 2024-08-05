using ECX.HR.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class MedicalBalances : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid Id { get; set; }
        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
        [ForeignKey("MedicalFund")]
        public Guid MedicalRequestId { get; set; }
        [ForeignKey("Spouse")]
        public Guid SpouseId { get; set; }
        public Double SelfBalance { get; set; }
        public Double FamilyBalance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }

    }
}
