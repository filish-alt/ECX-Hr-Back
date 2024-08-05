using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Queries;
using ECX.HR.Application.CQRS.Deduction.Request.Queries;
using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.DTOs.Deduction;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Handler.Queries
{
    public class GetDeductionDetailRequestHandler : IRequestHandler<GetDeductionDetailRequest, DeductionDto>
    {

        private readonly IDeductionRepository _deductionRepository;
        private IMapper _mapper;
        public GetDeductionDetailRequestHandler(IDeductionRepository DeductionRepository, IMapper mapper)
        {

           
           _deductionRepository = DeductionRepository;
            _mapper = mapper;
        }
        public async Task<DeductionDto> Handle(GetDeductionDetailRequest request, CancellationToken cancellationToken)
        {
            var Deduction = await _deductionRepository.GetById(request.Id);
            if (Deduction == null || Deduction.Status != 0)
                throw new NotFoundException(nameof(Deduction), request.Id);

            else
                return _mapper.Map<DeductionDto>(Deduction);
        }
    }
}
