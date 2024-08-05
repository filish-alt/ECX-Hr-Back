using ECX.HR.Application.DTOs.Tax;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Tax.Request.Command
{
    public class CreateTaxCommand : IRequest<BaseCommandResponse>
    {
        public TaxDto TaxDto { get; set; }
    }
}
