using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Queries;
using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestByIdCommandHandler : IRequestHandler<GetLeaveRequestByIdCommand, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestByIdCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestByIdCommand request, CancellationToken cancellationToken)
        {
            var leaverequest = await _leaveRequestRepository.GetByEmpId(request.EmpId);

            if (leaverequest == null || leaverequest.Any(we => we.Status != 0))
                throw new NotFoundException(nameof(leaverequest), request.EmpId);

            else
                return _mapper.Map<List<LeaveRequestDto>>(leaverequest);
        }
    }
}
