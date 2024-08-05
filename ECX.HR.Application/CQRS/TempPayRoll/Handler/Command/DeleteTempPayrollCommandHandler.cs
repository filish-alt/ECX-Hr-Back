using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.TempPayroll.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Handler.Command
{
    public class DeleteTempPayrollCommandHandler : IRequestHandler<DeleteTempPayrollCommand>
    {
        private ITempPayrollRepository _PayrollRepository;
        private IMapper _mapper;
        public DeleteTempPayrollCommandHandler(ITempPayrollRepository PayrollRepository, IMapper mapper)
        {
            _PayrollRepository = PayrollRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTempPayrollCommand request, CancellationToken cancellationToken)
        {
            var Payroll = await _PayrollRepository.GetById(request.Id);
            await _PayrollRepository.Delete(Payroll);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteTempPayrollCommand>.Handle(DeleteTempPayrollCommand request, CancellationToken cancellationToken)
        {
            var Payroll = await _PayrollRepository.GetById(request.Id);
            if (Payroll == null)
                throw new NotFoundException(nameof(Payroll), request.Id);
            await _PayrollRepository.Delete(Payroll);
        }
    }
}
