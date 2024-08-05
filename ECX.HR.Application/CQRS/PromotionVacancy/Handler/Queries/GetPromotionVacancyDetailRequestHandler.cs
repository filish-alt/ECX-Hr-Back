using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Queries;

using ECX.HR.Application.DTOs.PromotionVacancy;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Handler.Queries
{
    public class GetPromotionVacancyDetailRequestHandler : IRequestHandler<GetPromotionVacancyDetailRequest, PromotionVacancyDto>
    {
        private IPromotionVacancyRepository _PromotionVacancyRepository;
        private IMapper _mapper;
        public GetPromotionVacancyDetailRequestHandler(IPromotionVacancyRepository PromotionVacancyRepository, IMapper mapper)
        {
            _PromotionVacancyRepository = PromotionVacancyRepository;
            _mapper = mapper;
        }
        public async Task<PromotionVacancyDto> Handle(GetPromotionVacancyDetailRequest request, CancellationToken cancellationToken)
        {
            var PromotionVacancy =await _PromotionVacancyRepository.GetById(request.VacancyId);
           
            if (PromotionVacancy == null || PromotionVacancy.Status == 0)
                throw new NotFoundException(nameof(PromotionVacancy), request.VacancyId);

            else
                return _mapper.Map<PromotionVacancyDto>(PromotionVacancy);
        }
    }
}
