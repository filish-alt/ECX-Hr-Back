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
    public class AllowanceTypes : BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid Id { get; set; }
        public string Name { get; set; }
     
        public int Status { get; set; }
        public AllowanceTypes(Guid id, string name, int status)
        {
            Id = id;
            Name = name;
            Status = status;

        }
        public static AllowanceTypes FixedDeductioType1 = new AllowanceTypes(Guid.NewGuid(), "HardShip", 0);
        public static AllowanceTypes FixedDeductioType2 = new AllowanceTypes(Guid.NewGuid(), "Telephone", 0);
        public static AllowanceTypes FixedDeductioType3 = new AllowanceTypes(Guid.NewGuid(), "TaxExcemptedT", 0);
        public static AllowanceTypes FixedDeductioType4 = new AllowanceTypes(Guid.NewGuid(), "OtherTaxA", 0);
        public static AllowanceTypes FixedDeductioType5 = new AllowanceTypes(Guid.NewGuid(), "Housing", 0);
        public static AllowanceTypes FixedDeductioType6 = new AllowanceTypes(Guid.NewGuid(), "Living", 0);
        public static AllowanceTypes FixedDeductioType7 = new AllowanceTypes(Guid.NewGuid(), "SalaryAdvance", 0);
  


  
}
   
}
