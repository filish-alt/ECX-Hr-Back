using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Tax
{
    public class TaxDto: BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double SalaryStart { get; set; }
        public double SalaryEnd { get; set; }
        public double TaxRate { get; set; }
        public double DeductionAmount { get; set; }
        public int Status { get; set; }
    }
}
