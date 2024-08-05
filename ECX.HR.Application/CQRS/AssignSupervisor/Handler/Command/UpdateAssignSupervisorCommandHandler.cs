using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.AssignSupervisor.Request.Command;

using ECX.HR.Application.DTOs.AssignSupervisor.Validator;

using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AssignSupervisors.Handler.Command
{
    public class UpdateAssignSupervisorCommandHandler : IRequestHandler<UpdateAssignSupervisorCommand, Unit>
    {
        private IAssignSupervisorRepository _AssignSupervisorRepository;
        private IMapper _mapper;

        public UpdateAssignSupervisorCommandHandler(IAssignSupervisorRepository AssignSupervisorRepository, IMapper mapper)
        {
            _AssignSupervisorRepository = AssignSupervisorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAssignSupervisorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AssignSupervisorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AssignSupervisorDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.AssignSupervisorDto.UpdatedDate = DateTime.Now;
            var AssignSupervisor = await _AssignSupervisorRepository.GetById(request.AssignSupervisorDto.Id);

           

            _mapper.Map(request.AssignSupervisorDto, AssignSupervisor);

            await _AssignSupervisorRepository.Update(AssignSupervisor);
            return Unit.Value;
        }
    }
}

