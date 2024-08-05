using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Queries;
using ECX.HR.Application.CQRS.LeaveType.Request.Queries;
using ECX.HR.Application.DTOs.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestListCommand, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListHandler(ILeaveRequestRepository LeaveRequestepository, IMapper Mapper)
        {
            _leaveRequestepository = LeaveRequestepository;
            _mapper = Mapper;
        }
        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestepository.GetAllLeave();

            var activeLeaveRequest = leaveRequest.Where(leaverequest => leaverequest.Status == 0).ToList();



            return _mapper.Map<List<LeaveRequestDto>>(activeLeaveRequest);

        }
    }
}
