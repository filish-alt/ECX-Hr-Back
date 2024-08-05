using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Queries;

using ECX.HR.Application.DTOs.PromotionRelation;


using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Handler.Queries
{
    public class GetPromotionRelationListRequestHandler : IRequestHandler<GetPromotionRelationListRequest, List<PromotionRelationDto>>
    {
        private IPromotionRelationRepository _PromotionRelationRepository;
        private IMapper _mapper;
        public GetPromotionRelationListRequestHandler(IPromotionRelationRepository PromotionRelationRepository, IMapper mapper)
        {
            _PromotionRelationRepository= PromotionRelationRepository;
            _mapper = mapper;
        }
        public async Task<List<PromotionRelationDto>> Handle(GetPromotionRelationListRequest request, CancellationToken cancellationToken)
        {
            var PromotionRelation =await _PromotionRelationRepository.GetAll();
            var activePromotionRelation = PromotionRelation.Where(PromotionRelation => PromotionRelation.Status == 0).ToList();
            return _mapper.Map<List<PromotionRelationDto>>(activePromotionRelation);
        }
    }
}
