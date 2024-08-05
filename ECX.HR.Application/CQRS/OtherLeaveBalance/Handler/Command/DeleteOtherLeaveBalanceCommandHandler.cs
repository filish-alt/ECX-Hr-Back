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
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Command
{
    public class DeleteOtherLeaveBalanceCommandHandler : IRequestHandler<DeleteOtherLeaveBalanceCommand>
    {
        private IOtherLeaveBalanceRepository _OtherLeaveBalanceRepository;
        private IMapper _mapper;
        public DeleteOtherLeaveBalanceCommandHandler(IOtherLeaveBalanceRepository OtherLeaveBalanceRepository, IMapper mapper)
        {
            _OtherLeaveBalanceRepository = OtherLeaveBalanceRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteOtherLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var OtherLeaveBalance = await _OtherLeaveBalanceRepository.GetById(request.Id);

            if (OtherLeaveBalance == null)
                throw new NotFoundException(nameof(LeaveBalance), request.Id);

            // Assuming '1' represents the 'Deleted' status
            OtherLeaveBalance.Status = 1;

            await _OtherLeaveBalanceRepository.Update(OtherLeaveBalance); // Update theotherLeaveBalance with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteOtherLeaveBalanceCommand>.Handle(DeleteOtherLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var otherLeaveBalance = await _OtherLeaveBalanceRepository.GetById(request.Id);
            if (otherLeaveBalance == null)
                throw new NotFoundException(nameof(OtherLeaveBalance), request.Id);
            otherLeaveBalance.Status = 1;
            await _OtherLeaveBalanceRepository.Update(otherLeaveBalance);
        }
    }
}
