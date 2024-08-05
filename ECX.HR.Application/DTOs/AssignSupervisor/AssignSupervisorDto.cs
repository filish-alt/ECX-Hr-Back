using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.AssignSupervisor
{
    public class AssignSupervisorDto: BaseDtos
    {


        public int PId { get; set; }
        public Guid Id { get; set; }
        public Guid? PositionId { get; set; }
        public string FirstSupervisor { get; set; }
        public string SecondSupervisor { get; set; }
        public string ThirdSupervisor { get; set; }
        public string FourthSupervisor { get; set; }
        public string FifthSupervisor { get; set; }
        public int Status { get; set; }
    }
}
