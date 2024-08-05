using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.CQRS.Allowances.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveType.Handler.Command
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
       
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler (ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.GetById(request.leaveTypeId);
            await _leaveTypeRepository.Delete(leavetype);
            return Unit.Value;
        }


        async Task IRequestHandler<DeleteLeaveTypeCommand>.Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.GetById(request.leaveTypeId);
            if (leavetype == null)
                throw new NotFoundException(nameof(leavetype), request.leaveTypeId);
            await _leaveTypeRepository.Delete(leavetype);
        }
    }

}
