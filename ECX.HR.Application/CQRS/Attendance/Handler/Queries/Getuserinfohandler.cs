using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Attendance.Request.Queries;
using ECX.HR.Application.DTOs.Schedule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Queries
{
    public class Getuserinfohandler : IRequestHandler<getuser, List<NumOfRunDto>>
    {
        private IAttRepository _AttRepository;
        private IMapper _mapper;
        public Getuserinfohandler(IAttRepository AttRepository, IMapper mapper)
        {
            _AttRepository = AttRepository;
            _mapper = mapper;
        }
        public async Task<List<NumOfRunDto>> Handle(getuser request, CancellationToken cancellationToken)
        {
            var Att = await _AttRepository.GetNumOfRunDataFromSourceDatabase();
            var activeAttendance = Att.ToList();
            return _mapper.Map<List<NumOfRunDto>>(activeAttendance);
        }
    }
}
