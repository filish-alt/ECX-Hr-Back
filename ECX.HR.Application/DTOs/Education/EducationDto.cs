using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Education
{
    public class EducationDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public string NameOfInstitute { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string FieldOfStudy { get; set; }
        public string EductionName { get; set; }
        public int Status { get; set; }
        public string? File
        { get; set; }

    }
}
