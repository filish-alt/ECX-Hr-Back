using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.MedicalFunds
{
    public class MedicalFundDto : BaseDtos
    {

        public int PId { get; set; }
        public Guid MedicalRequestId { get; set; }
        public Guid EmpId { get; set; }
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string ApprovalStatus { get; set; }
        public double MedicalExamination { get; set; }
        public double Laboratory { get; set; }
        public double Medicine { get; set; }
        public double HospitalBed { get; set; }
        public double OtherRelated { get; set; }
        public double Total { get; set; }
        public double TotalFund { get; set; }
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
