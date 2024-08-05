using ECX.HR.Application.DTOs.Bank;
using ECX.HR.Application.DTOs.Branchs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Bank.Request.Command
{
    public class UpdateBankCommand : IRequest<Unit>
    {
        public BankDto BankDto { get; set; }
    }
}
