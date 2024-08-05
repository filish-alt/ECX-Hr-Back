using AutoMapper;
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Command;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Handler.Command
{
    public class DeletePromotionRelationCommandHandler : IRequestHandler<DeletePromotionRelationCommand>
    {
        private IPromotionRelationRepository _PromotionVacancyRepository;
        private IMapper _mapper;
        public DeletePromotionRelationCommandHandler(IPromotionRelationRepository PromotionVacancyRepository, IMapper mapper)
        {
            _PromotionVacancyRepository = PromotionVacancyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePromotionRelationCommand request, CancellationToken cancellationToken)
        {
            var PromotionVacancy = await _PromotionVacancyRepository.GetById(request.Id);
            await _PromotionVacancyRepository.Delete(PromotionVacancy);
            return Unit.Value;
        }

        async Task IRequestHandler<DeletePromotionRelationCommand>.Handle(DeletePromotionRelationCommand request, CancellationToken cancellationToken)
        {
            var PromotionVacancy = await _PromotionVacancyRepository.GetById(request.Id);
            if(PromotionVacancy == null) 
                throw new NotFoundException(nameof(PromotionVacancy), request.Id);
            PromotionVacancy.Status = 1;
            await _PromotionVacancyRepository.Update(PromotionVacancy);
           
        }
    }
}
