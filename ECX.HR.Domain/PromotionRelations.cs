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
    public class PromotionRelations : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("PromotionVacancys")]
        public Guid VacancyId { get; set; }
  
          [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
     
        public DateTime ApprovedDate { get; set; }
        public String PromotionStatus { get; set; }
        public String File { get; set; }
        public String Evaluation { get; set; }
        public int Status { get; set; }

        public virtual Employees Employees { get; set; }



    }
}
