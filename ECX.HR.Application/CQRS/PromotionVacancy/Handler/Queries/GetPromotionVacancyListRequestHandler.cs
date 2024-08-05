using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Queries;
using ECX.HR.Application.DTOs.PromotionVacancy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Handler.Queries
{
    public class GetPromotionVacancyListRequestHandler : IRequestHandler<GetPromotionVacancyListRequest, List<PromotionVacancyDto>>
    {
        private IPromotionVacancyRepository _PromotionVacancyRepository;
        private IMapper _mapper;
        public GetPromotionVacancyListRequestHandler(IPromotionVacancyRepository PromotionVacancyRepository, IMapper mapper)
        {
            _PromotionVacancyRepository= PromotionVacancyRepository;
            _mapper = mapper;
        }
        public async Task<List<PromotionVacancyDto>> Handle(GetPromotionVacancyListRequest request, CancellationToken cancellationToken)
        {
            var PromotionVacancy =await _PromotionVacancyRepository.GetAll();
            var activePromotionVacancy = PromotionVacancy.Where(PromotionVacancy => PromotionVacancy.Status == 0).ToList();
            return _mapper.Map<List<PromotionVacancyDto>>(activePromotionVacancy);
        }
    }
}
