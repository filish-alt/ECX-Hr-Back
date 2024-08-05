using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveRequest.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;
        BaseCommandResponse response;
       

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
       
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();




        var leaveRequest = _mapper.Map<LeaveRequests>(request.LeaveRequestDto);
            leaveRequest.leaveRequestId = Guid.NewGuid();
            var add = leaveRequest.leaveRequestId;
            var data = await _leaveRequestRepository.Add(leaveRequest);
            
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)add;
            return response;
        }
    }
}

