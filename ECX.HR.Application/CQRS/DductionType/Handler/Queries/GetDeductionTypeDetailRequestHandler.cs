using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Queries;
using ECX.HR.Application.DTOs.DeductionType;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DductionType.Handler.Queries
{
    public class GetDeductionTypeDetailRequestHandler : IRequestHandler<GetDeductionTypeDetailRequest,DeductionTypeDto>
    {
      
        private readonly IDeductionTypeRepository _deductionTypeRepository;
        private IMapper _mapper;
        public GetDeductionTypeDetailRequestHandler(IDeductionTypeRepository DeductionTypeRepository, IMapper mapper)
        {
            
           _deductionTypeRepository = DeductionTypeRepository;
            _mapper = mapper;
        }
        public async Task<DeductionTypeDto> Handle(GetDeductionTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var DeductionType = await _deductionTypeRepository.GetById(request.Id);
            if (DeductionType == null || DeductionType.Status != 0)
                throw new NotFoundException(nameof(DeductionType), request.Id);

            else
                return _mapper.Map<DeductionTypeDto>(DeductionType);
        }
    }
}
