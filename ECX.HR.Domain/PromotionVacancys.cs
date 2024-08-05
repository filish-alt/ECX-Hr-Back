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
    public class PromotionVacancys : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        public Guid VacancyId { get; set; }
        [ForeignKey("Positions")]
        public Guid PositionId { get; set; }
        [ForeignKey("Levels")]
        public Guid LevelId { get; set; }
        [ForeignKey("Branch")]
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
