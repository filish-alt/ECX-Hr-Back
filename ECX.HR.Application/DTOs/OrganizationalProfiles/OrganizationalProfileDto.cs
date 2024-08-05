using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.OrganizationalProfiles
{
    public class OrganizationalProfileDto : BaseDtos
    {
        public int PId { get; set; }
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
