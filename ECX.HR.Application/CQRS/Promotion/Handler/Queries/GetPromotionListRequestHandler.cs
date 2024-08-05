using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Promotion.Request.Queries;
using ECX.HR.Application.DTOs.Promotion;
using ECX.HR.Application.DTOs.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Promotion.Handler.Queries
{
    public class GetPromotionListRequestHandler : IRequestHandler<GetPromotionListRequest, List<PromotionDto>>
    {
        private IPromotionRepository _PromotionRepository;
        private IMapper _mapper;
        public GetPromotionListRequestHandler(IPromotionRepository PromotionRepository, IMapper mapper)
        {
            _PromotionRepository= PromotionRepository;
            _mapper = mapper;
        }
        public async Task<List<PromotionDto>> Handle(GetPromotionListRequest request, CancellationToken cancellationToken)
        {
            var Promotion =await _PromotionRepository.GetAll();
            var activePromotion = Promotion.Where(Promotion => Promotion.Status == 0).ToList();
            return _mapper.Map<List<PromotionDto>>(activePromotion);
        }
    }
}
