using AutoMapper;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Promotion.Request.Command;

namespace ECX.HR.Application.CQRS.Promotion.Handler.Command
{
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand>
    {
        private IPromotionRepository _PromotionRepository;
        private IMapper _mapper;
        public DeletePromotionCommandHandler(IPromotionRepository PromotionRepository, IMapper mapper)
        {
            _PromotionRepository = PromotionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var Promotion = await _PromotionRepository.GetById(request.Id);
            await _PromotionRepository.Delete(Promotion);
            return Unit.Value;
        }

        async Task IRequestHandler<DeletePromotionCommand>.Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var Promotion = await _PromotionRepository.GetById(request.Id);
            if(Promotion == null) 
                throw new NotFoundException(nameof(Promotion), request.Id);
            Promotion.Status = 1;
            await _PromotionRepository.Update(Promotion);
        }
    }
}
