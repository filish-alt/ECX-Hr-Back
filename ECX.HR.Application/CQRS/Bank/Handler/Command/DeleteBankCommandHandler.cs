using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Bank.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Bank.Handler.Command
{
    public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand>
    {
        private IBankRepository _BankRepository;
        private IMapper _mapper;
        public DeleteBankCommandHandler(IBankRepository BankRepository, IMapper mapper)
        {
            _BankRepository = BankRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var Bank = await _BankRepository.GetById(request.Id);
            await _BankRepository.Delete(Bank);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteBankCommand>.Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var Bank = await _BankRepository.GetById(request.Id);
            if (Bank == null)
                throw new NotFoundException(nameof(Bank), request.Id);
            Bank.Status = 1;
            await _BankRepository.Update(Bank);
        }
    }
}
