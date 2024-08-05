using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AssignSupervisor.Request.Command;
using ECX.HR.Application.DTOs.AssignSupervisor.Validator;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisor.Handler.Command
{
    public class CreateAssignSupervisorCommandHandler : IRequestHandler<CreateAssignSupervisorCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IAssignSupervisorRepository _AssignSupervisorRepository;
        private IMapper _mapper;
        public CreateAssignSupervisorCommandHandler(IAssignSupervisorRepository AssignSupervisorRepository, IMapper mapper)
        {
            _AssignSupervisorRepository = AssignSupervisorRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAssignSupervisorCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new AssignSupervisorDtoValidator();
            var validationResult =await validator.ValidateAsync(request.AssignSupervisorDetailDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var AssignSupervisor = _mapper.Map<AssignSupervisorss>(request.AssignSupervisorDetailDto);
            AssignSupervisor.Id = Guid.NewGuid();
            var add = AssignSupervisor.Id;
            var data =await _AssignSupervisorRepository.Add(AssignSupervisor);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)add;
            return response;
        }
    }
}
