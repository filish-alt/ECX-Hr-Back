using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Attendance.Request.Queries;

using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Exceptions;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Queries
{
    public class GetAttendanceDetailRequestHandler : IRequestHandler<GetAttendanceDetailRequest, AttendanceDto>
    {
        private IAttendanceRepository _AttendanceRepository;
        private IMapper _mapper;
        public GetAttendanceDetailRequestHandler(IAttendanceRepository AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }
        public async Task<AttendanceDto> Handle(GetAttendanceDetailRequest request, CancellationToken cancellationToken)
        {
            var Attendance =await _AttendanceRepository.GetById(request.Id);
           
            if (Attendance == null || Attendance.Status != 0)
                throw new NotFoundException(nameof(Attendance), request.Id);

            else
                return _mapper.Map<AttendanceDto>(Attendance);
        }
    }
}
