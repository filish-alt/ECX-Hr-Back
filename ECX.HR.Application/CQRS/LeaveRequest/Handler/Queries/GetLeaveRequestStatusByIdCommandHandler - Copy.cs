using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Queries;
using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestStatusByIdCommandHandler : IRequestHandler<GetLeaveRequestStatusByIdCommand, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestStatusByIdCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestStatusByIdCommand request, CancellationToken cancellationToken)
        {
            // Retrieve leave requests with the specified leave status and where status is not 1 (assuming status is an int field)
            var leaveRequests = await _leaveRequestRepository.GetByStatus(request.LeaveStatus,request.Supervisor);

            // Filter leave requests with status not equal to 1
            var filteredLeaveRequests = leaveRequests.FindAll(lr => lr.Status != 1);

            // If there are no matching leave requests, throw a NotFoundException
            if (filteredLeaveRequests.Count == 0)
            {
                throw new NotFoundException(nameof(leaveRequests), request.LeaveStatus);
            }

            // Map the filtered leave requests to LeaveRequestDto
            return _mapper.Map<List<LeaveRequestDto>>(filteredLeaveRequests);
        }
    }
}
