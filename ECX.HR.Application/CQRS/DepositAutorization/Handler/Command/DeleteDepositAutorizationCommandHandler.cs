using AutoMapper;
using ECX.HR.Application.CQRS.DepositAutorization.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.DepositAutorization.Handler.Command
{
    public class DeleteDepositAutorizationCommandHandler : IRequestHandler<DeleteDepositAutorizationCommand>
    {
        private IDepositAutorizationRepository _DepositAutorizationRepository;
        private IMapper _mapper;
        public DeleteDepositAutorizationCommandHandler(IDepositAutorizationRepository DepositAutorizationRepository, IMapper mapper)
        {
            _DepositAutorizationRepository = DepositAutorizationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDepositAutorizationCommand request, CancellationToken cancellationToken)
        {
            var DepositAutorization = await _DepositAutorizationRepository.GetById(request.Id);
            DepositAutorization.Status = 1;
            await _DepositAutorizationRepository.Update(DepositAutorization);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteDepositAutorizationCommand>.Handle(DeleteDepositAutorizationCommand request, CancellationToken cancellationToken)
        {
            var DepositAutorization = await _DepositAutorizationRepository.GetById(request.Id);
            if(DepositAutorization == null) 
                throw new NotFoundException(nameof(DepositAutorization), request.Id);
            DepositAutorization.Status = 1;
            await _DepositAutorizationRepository.Update(DepositAutorization);
        }
    }
}
