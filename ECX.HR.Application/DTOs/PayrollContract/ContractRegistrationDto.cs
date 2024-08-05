using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.PayrollContract
{
    public class ContractRegistrationDto : BaseDtos
    {

        public int PId { get; set; }
        public Guid EmpId { get; set; }
        public string EcxId { get; set; }
        public string AdId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public string sex { get; set; }
        public DateTime DateOfBitrh { get; set; }
        public string PlaceOfBith { get; set; }
        public string MartialStatus { get; set; }
        public string salutation { get; set; }
        public string Nationality { get; set; }
        public string PensionNo { get; set; }
        public string ImageData { get; set; }
        public bool crime { get; set; }
        public string CrimeDescription { get; set; }


        public Guid DivisionId { get; set; }
        public Guid StepId { get; set; }
        public Guid BranchId { get; set; }
        public Guid position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid BankId { get; set; }
        public string BankBranch { get; set; }
        public long BankAccount { get; set; }
        public string TinNumber { get; set; }

        public int Status { get; set; }
    }
}
