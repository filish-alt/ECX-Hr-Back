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
    public class Taxs : BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double SalaryStart { get; set; }
        public double SalaryEnd { get; set; }
        public double TaxRate { get; set; }
        public double DeductionAmount { get; set; }
        public int Status { get; set; }
        

    }
}
