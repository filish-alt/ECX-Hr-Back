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
    public class OrganizationalProfiles : BaseDomainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]
        
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string city { get; set; }
        public string Location { get; set; }
        public int PhoneNumber { get; set; }
        public int AltPhone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string PoBox { get; set; }
        public string Manager { get; set; }
        public int VatNumber { get; set; }
        public int TinNumber { get; set; }
        public int Status { get; set; }
    }
}
