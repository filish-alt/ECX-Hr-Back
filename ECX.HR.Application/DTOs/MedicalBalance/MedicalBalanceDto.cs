using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.MedicalBalance
{
    public class MedicalBalanceDto : BaseDtos
    { public int PId { get; set; }
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
         public Guid MedicalRequestId { get; set; }
         public Guid SpouseId { get; set; }
        public Double SelfBalance { get; set; }
        public Double FamilyBalance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
