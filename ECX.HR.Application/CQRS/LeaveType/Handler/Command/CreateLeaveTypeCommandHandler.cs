using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.DTOs.Address.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveType.Handler.Command
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();

            var leaveType = _mapper.Map<LeaveTypes>(request.LeaveTypeDto);
            leaveType.leaveTypeId = Guid.NewGuid();
           var add = leaveType.leaveTypeId;
            var data = await _leaveTypeRepository.Add(leaveType);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)add;
            return response;
        }
    }
}
