using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Queries;
using ECX.HR.Application.DTOs.DeductionType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DductionType.Handler.Queries
{
    public class GetDeductionTypeListRequestHandler : IRequestHandler<GetDeductionTypeListRequest,List<DeductionTypeDto>>
    {
    
        private readonly IDeductionTypeRepository _deductionTypeRepository;
        private IMapper _mapper;
        public GetDeductionTypeListRequestHandler(IDeductionTypeRepository DeductionTypeRepository, IMapper mapper)

        {
            _deductionTypeRepository = DeductionTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<DeductionTypeDto>> Handle(GetDeductionTypeListRequest request, CancellationToken cancellationToken)
        {
            var DeductionType=await _deductionTypeRepository.GetAll();
            var activeDeductionType = DeductionType.Where(DeductionType => DeductionType.Status == 0).ToList();
            return _mapper.Map<List<DeductionTypeDto>>(activeDeductionType);
        }
    }
}




