using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Tax.Request.Queries;
using ECX.HR.Application.DTOs.Tax;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Tax.Handler.Queries
{
    public class GetTaxDetailRequestHandler : IRequestHandler<GetTaxDetailRequest, TaxDto>
    {
        private ITaxRepository _TaxRepository;
        private IMapper _mapper;
        public GetTaxDetailRequestHandler(ITaxRepository TaxRepository, IMapper mapper)
        {
            _TaxRepository = TaxRepository;
            _mapper = mapper;
        }
        public async Task<TaxDto> Handle(GetTaxDetailRequest request, CancellationToken cancellationToken)
        {
            var Tax = await _TaxRepository.GetById(request.Id);

            if (Tax == null || Tax.Status != 0)
                throw new NotFoundException(nameof(Tax), request.Id);

            else
                return _mapper.Map<TaxDto>(Tax);
        }
    }
}
