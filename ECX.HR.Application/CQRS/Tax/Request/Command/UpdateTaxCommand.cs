using ECX.HR.Application.DTOs.Supervisors;
using ECX.HR.Application.DTOs.Tax;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Tax.Request.Command
{
    public class UpdateTaxCommand : IRequest<Unit>
    {
        public TaxDto TaxDto { get; set; }
    }
}
