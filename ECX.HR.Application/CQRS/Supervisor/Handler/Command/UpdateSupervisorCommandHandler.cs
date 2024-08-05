using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Supervisor.Request.Command;

using ECX.HR.Application.DTOs.Supervisors.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Supervisor.Handler.Command
{
    public class UpdateSupervisorCommandHandler : IRequestHandler<UpdateSupervisorCommand, Unit>
    {
        private ISupervisiorRepository _SupervisorRepository;
        private IMapper _mapper;
        public UpdateSupervisorCommandHandler(ISupervisiorRepository SupervisorRepository, IMapper mapper)
        {
            _SupervisorRepository = SupervisorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var validator = new SupervisorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SupervisorDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Supervisor = await _SupervisorRepository.GetById(request.SupervisorDto.Id);
            _mapper.Map(request.SupervisorDto, Supervisor);
            await _SupervisorRepository.Update(Supervisor);
            return Unit.Value;
        }
    }
}
