using AutoMapper;
using ECX.HR.Application.CQRS.Position.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Position.Handler.Command
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
    {
        private IPositionRepository _PositionRepository;
        private IMapper _mapper;
        public DeletePositionCommandHandler(IPositionRepository PositionRepository, IMapper mapper)
        {
            _PositionRepository = PositionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var Position = await _PositionRepository.GetById(request.PositionId);
            await _PositionRepository.Delete(Position);
            return Unit.Value;
        }

        async Task IRequestHandler<DeletePositionCommand>.Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var Position = await _PositionRepository.GetById(request.PositionId);
            if(Position == null) 
                throw new NotFoundException(nameof(Position), request.PositionId);
            Position.Status = 1;
            await _PositionRepository.Update(Position);
           
        }
    }
}
