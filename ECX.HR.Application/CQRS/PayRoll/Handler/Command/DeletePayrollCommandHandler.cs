using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.PayRoll.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Handler.Command
{
    public class DeletePayrollCommandHandler : IRequestHandler<DeletePayrollCommand>
    {
        private IPayrollRepository _PayrollRepository;
        private IMapper _mapper;
        public DeletePayrollCommandHandler(IPayrollRepository PayrollRepository, IMapper mapper)
        {
            _PayrollRepository = PayrollRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePayrollCommand request, CancellationToken cancellationToken)
        {
            var Payroll = await _PayrollRepository.GetById(request.Id);
            await _PayrollRepository.Delete(Payroll);
            return Unit.Value;
        }

        async Task IRequestHandler<DeletePayrollCommand>.Handle(DeletePayrollCommand request, CancellationToken cancellationToken)
        {
            var Payroll = await _PayrollRepository.GetById(request.Id);
            if (Payroll == null)
                throw new NotFoundException(nameof(Payroll), request.Id);
            await _PayrollRepository.Delete(Payroll);
        }
    }
}
