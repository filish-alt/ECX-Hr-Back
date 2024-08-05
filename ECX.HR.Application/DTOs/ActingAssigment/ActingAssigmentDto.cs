using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.ActingAssigment
{
    public class ActingAssigmentDto : BaseDtos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid Id { get; set; }
        public Guid RequesterEmp { get; set; }
        public Guid AssignedEmp { get; set; }
        public string Postion { get; set; }
        public string Grade { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string FirstSupervisorStatus { get; set; }
        public string SecondSupervisorStatus { get; set; }
        public string ThirdSupervisorStatus { get; set; }

        public int Status { get; set; }
    }
}
