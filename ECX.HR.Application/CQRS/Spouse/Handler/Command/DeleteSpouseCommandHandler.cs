using AutoMapper;
using ECX.HR.Application.CQRS.Spouse.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Spouse.Handler.Command
{
    public class DeleteSpouseCommandHandler : IRequestHandler<DeleteSpouseCommand>
    {
        private ISpouseRepository _SpouseRepository;
        private IMapper _mapper;
        public DeleteSpouseCommandHandler(ISpouseRepository SpouseRepository, IMapper mapper)
        {
            _SpouseRepository = SpouseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSpouseCommand request, CancellationToken cancellationToken)
        {
            var Spouse = await _SpouseRepository.GetById(request.Id);
            Spouse.Status = 1;
            await _SpouseRepository.Update(Spouse);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteSpouseCommand>.Handle(DeleteSpouseCommand request, CancellationToken cancellationToken)
        {
            var Spouse = await _SpouseRepository.GetById(request.Id);
            if(Spouse == null) 
                throw new NotFoundException(nameof(Spouse), request.Id);
            Spouse.Status = 1;
            await _SpouseRepository.Update(Spouse);
        }
    }
}
