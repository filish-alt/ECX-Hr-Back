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
using ECX.HR.Application.CQRS.LeaveBalance.Request.Command;

namespace ECX.HR.Application.CQRS.LeaveBalance.Handler.Command
{
    public class DeleteLeaveBalanceCommandHandler : IRequestHandler<DeleteLeaveBalanceCommand>
    {
        private ILeaveBalanceRepository _LeaveBalanceRepository;
        private IMapper _mapper;
        public DeleteLeaveBalanceCommandHandler(ILeaveBalanceRepository LeaveBalanceRepository, IMapper mapper)
        {
            _LeaveBalanceRepository = LeaveBalanceRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var leaveBalance = await _LeaveBalanceRepository.GetById(request.Id);

            if (leaveBalance == null)
                throw new NotFoundException(nameof(LeaveBalance), request.Id);

            // Assuming '1' represents the 'Deleted' status
            leaveBalance.Status = 1;

            await _LeaveBalanceRepository.Update(leaveBalance); // Update the LeaveBalance with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteLeaveBalanceCommand>.Handle(DeleteLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var leaveBalance = await _LeaveBalanceRepository.GetById(request.Id);
            if (leaveBalance == null)
                throw new NotFoundException(nameof(LeaveBalance), request.Id);
            leaveBalance.Status = 1;
            await _LeaveBalanceRepository.Update(leaveBalance);
        }
    }
}
