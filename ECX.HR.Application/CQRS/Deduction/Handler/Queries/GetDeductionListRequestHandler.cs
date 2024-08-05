using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Queries;
using ECX.HR.Application.CQRS.Deduction.Request.Queries;
using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.DTOs.Deduction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Handler.Queries
{
    public class GetDeductionListRequestHandler : IRequestHandler<GetDeductionListRequest, List<DeductionDto>>
    {


        private readonly IDeductionRepository _deductionRepository;
        private IMapper _mapper;
        public GetDeductionListRequestHandler(IDeductionRepository DeductionRepository, IMapper mapper)

        {
     
           _deductionRepository = DeductionRepository;
            _mapper = mapper;
        }
        public async Task<List<DeductionDto>> Handle(GetDeductionListRequest request, CancellationToken cancellationToken)
        {
            var Deduction = await _deductionRepository.GetAll();
            var activeDeduction = Deduction.Where(Deduction => Deduction.Status == 0).ToList();
            return _mapper.Map<List<DeductionDto>>(activeDeduction);
        }
    }
}


