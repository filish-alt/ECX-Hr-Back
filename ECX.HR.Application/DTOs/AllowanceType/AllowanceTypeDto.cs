using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.AllowanceType
{
    public class AllowanceTypeDto: BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Status { get; set; }
    }
}
