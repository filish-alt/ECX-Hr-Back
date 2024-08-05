using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.PromotionVacancy
{
    public class PromotionVacancyDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid PositionId { get; set; }
        public Guid VacancyId { get; set; }
        public Guid LevelId { get; set; }
        public Guid BranchId { get; set; }
        public string Requirement { get; set; }
        public string Availability { get; set; }
        public string Purpose { get; set; }
        public string Responsibility { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Deadline { get; set; }
        public int Status { get; set; }
    }
}