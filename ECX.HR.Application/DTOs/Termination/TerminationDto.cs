using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Termination
{
    public class TerminationDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid EmpId { get; set; }
        public Guid Id { get; set; }
        public Guid PositionId { get; set; }
        public Guid LevelId { get; set; }
        public string TerminationType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string TerminationStatus { get; set; }
        public string Supervisor { get; set; }
        public int Status { get; set; }

    }
}
