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
    public class MedicalFunds : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid MedicalRequestId { get; set; }
        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string ApprovalStatus { get; set; }
        public Double MedicalExamination { get; set; }
        public Double Laboratory { get; set; }
        public Double Medicine { get; set; }
        public Double HospitalBed { get; set; }
        public Double OtherRelated { get; set; }
        public Double Total { get; set; }
        public Double TotalFund { get; set; }
        public string? File
        { get; set; }
        public string? ReceiptFile
        { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Supervisor { get; set; }
        public Guid? SpouseId { get; set; }
    }
}
