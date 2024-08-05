using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Attendance.Request.Queries;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Queries
{
    public class GetAttendanceListRequestHandler : IRequestHandler<GetAttendanceListRequest, List<AttendanceDto>>
    {
        private IAttendanceRepository _AttendanceRepository;
        private IMapper _mapper;
        public GetAttendanceListRequestHandler(IAttendanceRepository AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository= AttendanceRepository;
            _mapper = mapper;
        }
        public async Task<List<AttendanceDto>> Handle(GetAttendanceListRequest request, CancellationToken cancellationToken)
        {
            var Attendance =await _AttendanceRepository.GetAll();
            var activeAttendance = Attendance.Where(Attendance => Attendance.Status == 0).ToList();
            return _mapper.Map<List<AttendanceDto>>(activeAttendance);
        }
    }
}
