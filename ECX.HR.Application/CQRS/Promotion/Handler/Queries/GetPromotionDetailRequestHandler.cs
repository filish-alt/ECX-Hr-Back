using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Level.Request.Queries;
using ECX.HR.Application.CQRS.Promotion.Request.Queries;
using ECX.HR.Application.DTOs.EmployeeStatuss;
using ECX.HR.Application.DTOs.Promotion;
using ECX.HR.Application.DTOs.Promotions;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Promotion.Handler.Queries
{
    public class GetPromotionDetailRequestHandler : IRequestHandler<GetPromotionDetailRequest, PromotionDto>
    {
        private IPromotionRepository _PromotionRepository;
        private IMapper _mapper;
        public GetPromotionDetailRequestHandler(IPromotionRepository PromotionRepository, IMapper mapper)
        {
            _PromotionRepository = PromotionRepository;
            _mapper = mapper;
        }
        public async Task<PromotionDto> Handle(GetPromotionDetailRequest request, CancellationToken cancellationToken)
        {
            var Promotion =await _PromotionRepository.GetById(request.Id);
           
            if (Promotion == null || Promotion.Status != 0)
                throw new NotFoundException(nameof(Promotion), request.Id);

            else
                return _mapper.Map<PromotionDto>(Promotion);
        }
    }
}
