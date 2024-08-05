using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Queries;
using ECX.HR.Application.DTOs.PromotionRelation;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Handler.Queries
{
    public class GetPromotionRelationDetailRequestHandler : IRequestHandler<GetPromotionRelationDetailRequest, List<PromotionRelationDto>>
    {
        private IPromotionRelationRepository _PromotionRelationRepository;
        private IMapper _mapper;
        public GetPromotionRelationDetailRequestHandler(IPromotionRelationRepository PromotionRelationRepository, IMapper mapper)
        {
            _PromotionRelationRepository = PromotionRelationRepository;
            _mapper = mapper;
        }
        public async Task<List<PromotionRelationDto>> Handle(GetPromotionRelationDetailRequest request, CancellationToken cancellationToken)
        {
            var PromotionRelation =await _PromotionRelationRepository.GetByEmpId(request.empId);

            if (PromotionRelation == null || PromotionRelation.Any(we => we.Status != 0))
                throw new NotFoundException(nameof(PromotionRelation), request.empId);

            else
                return _mapper.Map<List<PromotionRelationDto>>(PromotionRelation);
        }

       
    }
}
