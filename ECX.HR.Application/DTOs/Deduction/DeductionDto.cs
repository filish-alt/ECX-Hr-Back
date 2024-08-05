using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.DTOs.Common;

namespace ECX.HR.Application.DTOs.Deduction
{
    public class DeductionDto :BaseDtos
    {

        public int PId { get; set; }
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public Guid DeductionType { get; set; }
        public string File { get; set; }
        public string Remark { get; set; }
        public double Amount { get; set; }
        public double Length { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
