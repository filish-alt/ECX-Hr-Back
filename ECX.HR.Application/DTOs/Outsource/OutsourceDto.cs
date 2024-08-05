using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Outsource
{
    public class OutsourceDto
    {
        public int PId { get; set; }
        public Guid Id { get; set; } 
        public string File { get; set; }
        public string Remark { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

     
    }
}
