using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.PromotionRelation
{
    public class PromotionRelationDto : BaseDtos
    {
        public int PId { get; set; }
       
        public Guid Id { get; set; }
        public Guid VacancyId { get; set; }

        public Guid EmpId { get; set; }

        public DateTime ApprovedDate { get; set; }
        public String File { get; set; }
        public String Evaluation { get; set; }
        public String PromotionStatus { get; set; }
        public int Status { get; set; }

      
    }
}