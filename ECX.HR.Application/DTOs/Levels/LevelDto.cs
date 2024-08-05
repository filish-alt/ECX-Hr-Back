using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Levels
{
    public class LevelDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid LevelId { get; set; }
        public Guid PositionId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}
