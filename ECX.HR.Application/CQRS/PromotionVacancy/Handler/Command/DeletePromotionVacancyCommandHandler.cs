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

namespace ECX.HR.Application.CQRS.PromotionVacancy.Handler.Command
{
    public class DeletePromotionVacancyCommandHandler : IRequestHandler<DeletePromotionVacancyCommand>
    {
        private IPromotionVacancyRepository _PromotionVacancyRepository;
        private IMapper _mapper;
        public DeletePromotionVacancyCommandHandler(IPromotionVacancyRepository PromotionVacancyRepository, IMapper mapper)
        {
            _PromotionVacancyRepository = PromotionVacancyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePromotionVacancyCommand request, CancellationToken cancellationToken)
        {
            var PromotionVacancy = await _PromotionVacancyRepository.GetById(request.VacancyId);
            await _PromotionVacancyRepository.Delete(PromotionVacancy);
            return Unit.Value;
        }

        async Task IRequestHandler<DeletePromotionVacancyCommand>.Handle(DeletePromotionVacancyCommand request, CancellationToken cancellationToken)
        {
            var PromotionVacancy = await _PromotionVacancyRepository.GetById(request.VacancyId);
            if(PromotionVacancy == null) 
                throw new NotFoundException(nameof(PromotionVacancy), request.VacancyId);
            PromotionVacancy.Status = 1;
            await _PromotionVacancyRepository.Update(PromotionVacancy);
           
        }
    }
}
