using AutoMapper;
using ECX.HR.Application.CQRS.Level.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Level.Handler.Command
{
    public class DeleteLevelCommandHandler : IRequestHandler<DeleteLevelCommand>
    {
        private ILevelRepository _LevelRepository;
        private IMapper _mapper;
        public DeleteLevelCommandHandler(ILevelRepository LevelRepository, IMapper mapper)
        {
            _LevelRepository = LevelRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
        {
            var Level = await _LevelRepository.GetById(request.LevelId);
            await _LevelRepository.Delete(Level);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteLevelCommand>.Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
        {
            var Level = await _LevelRepository.GetById(request.LevelId);
            if(Level == null) 
                throw new NotFoundException(nameof(Level), request.LevelId);
            Level.Status = 1;
            await _LevelRepository.Update(Level);
        }
    }
}
