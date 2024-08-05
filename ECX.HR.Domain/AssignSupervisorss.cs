using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ECX.HR.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ECX.HR.Domain
{
    public class AssignSupervisorss :BaseDomainEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
      
        public Guid Id { get; set; }
        [ForeignKey("Position")]
        public Guid? PositionId { get; set; }
        public string FirstSupervisor { get; set; }
        public string SecondSupervisor { get; set; }
        public string ThirdSupervisor { get; set; }
        public string FourthSupervisor { get; set; }
        public string FifthSupervisor { get; set; }
        public int Status { get; set; }
    }
}
