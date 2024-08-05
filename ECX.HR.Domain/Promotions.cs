using ECX.HR.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class Promotions :BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("PositionVacancys")]
        public Guid VacancyId { get; set; }
        [ForeignKey("Positions")]
        public Guid PositionId { get; set; }
        [ForeignKey("Levels")]
        public Guid LevelId { get; set; }
        [ForeignKey("Employees")]
        public Guid EmpId { get; set; }

        public DateTime StartDate { get; set; }

        public int Status { get; set; }
        public virtual Employees Employees { get; set; }


    }
}
