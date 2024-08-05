using ECX.HR.Application.DTOs.Bank;
using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Bank.Request.Command
{
    public class CreateBankCommand : IRequest<BaseCommandResponse>
    {
        public BankDto BankDto { get; set; }
    }
}
