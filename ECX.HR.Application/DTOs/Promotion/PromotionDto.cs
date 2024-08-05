using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Promotion
{
    public class PromotionDto : BaseDtos
    {
        public int PId { get; set; }


        public Guid Id { get; set; }
        public Guid VacancyId { get; set; }

        public Guid PositionId { get; set; }
        public Guid BranchId { get; set; }

        public Guid LevelId { get; set; }

        public Guid EmpId { get; set; }

        public DateTime StartDate { get; set; }

        public int Status { get; set; }

    }
}
