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
    public class Employees : BaseDomainEntity
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        public Guid EmpId { get; set; }
        public string EcxId { get; set; }
        public string AdId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public string sex { get; set; }
        public DateTime DateOfBityh { get; set; }
        public string PlaceOfBith { get; set; }
        public string MartialStatus { get; set; }
        public string salutation { get; set; }
        public string Nationality { get; set; }
        public string PensionNo { get; set; }      
        public string ImageData { get; set; }
        public bool crime { get; set; }
        public string CrimeDescription{ get; set; }
   
        public int Status { get; set; }




        public string ? AttendanceId { get; set; } 

        public ICollection<WorkExperiences> WorkExperiences { get; set; }
        public ICollection<Educations> Educations { get; set; }

        public ICollection<Trainings> Trainings { get; set; }
        public ICollection<EmergencyContacts> EmergencyContacts { get; set; }

        public ICollection<Spouses> Spouses { get; set; }
        public ICollection<AnnualLeaveBalances> LeaveBalances { get; set; }

        public ICollection<Promotions> Promotions { get; set; }
        public ICollection<Terminations> Terminations { get; set; }
        public ICollection<PromotionRelations> PromotionRelations { get; set; }

    }
}
