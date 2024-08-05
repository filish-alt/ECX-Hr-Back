using ECX.HR.Application.DTOs.Common;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.DepositAutorizations
{
    public class DepositAutorizationDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }

        public Guid BankId { get; set; }
        public string BankBranch { get; set; }
        public long BankAccount { get; set; }
        public string TinNumber { get; set; }
        public int Status { get; set; }
    }
}
