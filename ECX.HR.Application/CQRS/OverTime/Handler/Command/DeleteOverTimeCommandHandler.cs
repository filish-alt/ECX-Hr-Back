using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.OverTime.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Handler.Command
{
    public class DeleteOverTimeCommandHandler : IRequestHandler<DeleteOverTimeCommand>
    {
        private IOverTimeRepository _OverTimeRepository;
        private IMapper _mapper;
        public DeleteOverTimeCommandHandler(IOverTimeRepository OverTimeRepository, IMapper mapper)
        {
            _OverTimeRepository = OverTimeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOverTimeCommand request, CancellationToken cancellationToken)
        {
            var OverTime = await _OverTimeRepository.GetById(request.Id);
            await _OverTimeRepository.Delete(OverTime);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteOverTimeCommand>.Handle(DeleteOverTimeCommand request, CancellationToken cancellationToken)
        {
            var OverTime = await _OverTimeRepository.GetById(request.Id);
            if (OverTime == null)
                throw new NotFoundException(nameof(OverTime), request.Id);
            await _OverTimeRepository.Delete(OverTime);
        }
    }
}
