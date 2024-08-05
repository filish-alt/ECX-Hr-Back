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
using ECX.HR.Application.CQRS.Attendance.Request.Command;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Command
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand>
    {
        private IAttendanceRepository _AttendanceRepository;
        private IMapper _mapper;
        public DeleteAttendanceCommandHandler(IAttendanceRepository AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var Attendance = await _AttendanceRepository.GetById(request.Id);
            await _AttendanceRepository.Delete(Attendance);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteAttendanceCommand>.Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var Attendance = await _AttendanceRepository.GetById(request.Id);
            if(Attendance == null) 
                throw new NotFoundException(nameof(Attendance), request.Id);
            Attendance.Status = 1;
            
            await _AttendanceRepository.Update(Attendance);
        }
    }
}
