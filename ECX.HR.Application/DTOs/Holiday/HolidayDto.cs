using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Holiday

{
   public class HolidayDto: BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
     
        public string Year { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }


    }
}

