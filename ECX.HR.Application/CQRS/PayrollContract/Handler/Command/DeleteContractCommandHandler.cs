using AutoMapper;
using ECX.HR.Application.ContractS.Persistence;
using ECX.HR.Application.CQRS.PayrollContract.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Contract.Handler.Command
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand>
    {
        private IPayrollContractRepository _ContractRepository;
        private IMapper _mapper;
        public DeleteContractCommandHandler(IPayrollContractRepository ContractRepository, IMapper mapper)
        {
            _ContractRepository = ContractRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var Contract = await _ContractRepository.GetById(request.Id);
            await _ContractRepository.Delete(Contract);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteContractCommand>.Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var Contract = await _ContractRepository.GetById(request.Id);
            if (Contract == null)
                throw new NotFoundException(nameof(Contract), request.Id);
            Contract.Status = 1;
            await _ContractRepository.Update(Contract);
        }
    }
}
