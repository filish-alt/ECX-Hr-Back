using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Tax.Request.Queries;
using ECX.HR.Application.DTOs.Tax;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Tax.Handler.Queries
{
    public class GetTaxListRequestHandler : IRequestHandler<GetTaxListRequest, List<TaxDto>>
    {
        private ITaxRepository _TaxRepository;
        private IMapper _mapper;
        public GetTaxListRequestHandler(ITaxRepository TaxRepository, IMapper mapper)
        {
            _TaxRepository = TaxRepository;
            _mapper = mapper;
        }
        public async Task<List<TaxDto>> Handle(GetTaxListRequest request, CancellationToken cancellationToken)
        {
            var Tax = await _TaxRepository.GetAll();
            var TaxLevel = Tax.Where(Tax => Tax.Status == 0).ToList();
            return _mapper.Map<List<TaxDto>>(TaxLevel);
        }
    }
}
