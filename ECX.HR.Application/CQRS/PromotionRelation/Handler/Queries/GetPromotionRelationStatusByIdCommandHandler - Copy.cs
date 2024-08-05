using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Promotion.Request.Queries;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Queries;
using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.DTOs.Promotion;
using ECX.HR.Application.DTOs.PromotionRelation;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Handler.Queries
{
    public class GetPromotionRelationStatusByIdCommandHandler : IRequestHandler<GetPromotionRelationStatusByIdCommand, List<PromotionRelationDto>>
    {
        private readonly IPromotionRelationRepository _PromotionRelationRepository;
        private readonly IMapper _mapper;

        public GetPromotionRelationStatusByIdCommandHandler(IPromotionRelationRepository PromotionRelationRepository, IMapper mapper)
        {
            _PromotionRelationRepository = PromotionRelationRepository;
            _mapper = mapper;
        }

        public async Task<List<PromotionRelationDto>> Handle(GetPromotionRelationStatusByIdCommand request, CancellationToken cancellationToken)
        {
            // Retrieve leave requests with the specified leave status and where status is not 1 (assuming status is an int field)
            var PromotionRelations = await _PromotionRelationRepository.GetByStatus(request.PromotionStatus);

            // Filter leave requests with status not equal to 1
            var filteredPromotions = PromotionRelations.FindAll(lr => lr.Status == 0);

            // If there are no matching leave requests, throw a NotFoundException
            if (filteredPromotions.Count == 0)
            {
                throw new NotFoundException(nameof(Promotions), request.PromotionStatus);
            }

            // Map the filtered leave requests to PromotionDto
            return _mapper.Map<List<PromotionRelationDto>>(filteredPromotions);
        }
    }
}
