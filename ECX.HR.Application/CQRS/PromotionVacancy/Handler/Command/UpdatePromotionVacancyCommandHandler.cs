using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Command;
using ECX.HR.Application.DTOs.PromotionVacancy.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Handler.Command
{
    public class UpdatePromotionVacancyCommandHandler : IRequestHandler<UpdatePromotionVacancyCommand, Unit>
    {
        private IPromotionVacancyRepository _PromotionVacancyRepository;
        private IMapper _mapper;
        public UpdatePromotionVacancyCommandHandler(IPromotionVacancyRepository PromotionVacancyRepository, IMapper mapper)
        {
            _PromotionVacancyRepository = PromotionVacancyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePromotionVacancyCommand request, CancellationToken cancellationToken)
        {
            var validator = new PromotionVacancyDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PromotionVacancyDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var PromotionVacancy = await _PromotionVacancyRepository.GetById(request.PromotionVacancyDto.VacancyId);
            _mapper.Map(request.PromotionVacancyDto, PromotionVacancy);
            await _PromotionVacancyRepository.Update(PromotionVacancy);
            return Unit.Value;
        }
    }
}
