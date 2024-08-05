using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Employees
{
    internal class EmpCreateDto
    {
       
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
        public string CrimeDescription { get; set; }
        public string FirstSupervisor { get; set; }
        public string SecondSupervisor { get; set; }
        public int Status { get; set; }
    }
}
