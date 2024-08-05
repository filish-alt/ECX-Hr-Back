using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.DTOs.Common;

namespace ECX.HR.Application.DTOs.Bank
{
    public class BankDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public int Status { get; set; }
    }
}
