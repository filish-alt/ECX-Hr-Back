using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Step

{
   public class StepDto: BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public Guid SalaryTypeId { get; set; }
        public Guid LevelId { get; set; }
        public int Status { get; set; }


    }
}

