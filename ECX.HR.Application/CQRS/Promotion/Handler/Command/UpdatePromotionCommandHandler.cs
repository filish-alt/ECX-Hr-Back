using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Promotion.Request.Command;
using ECX.HR.Application.DTOs.Promotions.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Promotion.Handler.Command
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, Unit>
    {
        private IPromotionRepository _PromotionRepository;
        private IMapper _mapper;
        public UpdatePromotionCommandHandler(IPromotionRepository PromotionRepository, IMapper mapper)
        {
            _PromotionRepository = PromotionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var validator = new PromotionDtoValidators();
            var validationResult = await validator.ValidateAsync(request.PromotionDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Promotion = await _PromotionRepository.GetById(request.PromotionDto.Id);
            _mapper.Map(request.PromotionDto, Promotion);
            await _PromotionRepository.Update(Promotion);
            return Unit.Value;
        }
    }
}
