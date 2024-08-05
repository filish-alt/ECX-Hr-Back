using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Command;

using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.DTOs.EmployeeStatus.Validator;

namespace ECX.HR.Application.CQRS.EmployeeStatus.Handler.Command
{
    public class UpdateEmployeeStatusCommandHandler : IRequestHandler<UpdateEmployeeStatusCommand, Unit>
    {
        private IEmployeeStatusRepository _EmployeeStatusRepository;
        private IMapper _mapper;
        public UpdateEmployeeStatusCommandHandler(IEmployeeStatusRepository EmployeeStatusRepository, IMapper mapper)
        {
            _EmployeeStatusRepository = EmployeeStatusRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new EmployeeStatusDtoValidators();  
            var validationResult = await validator.ValidateAsync(request.EmployeeStatusDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var EmployeeStatus = await _EmployeeStatusRepository.GetById(request.EmployeeStatusDto.Id);
            _mapper.Map(request.EmployeeStatusDto, EmployeeStatus);
            await _EmployeeStatusRepository.Update(EmployeeStatus);
            return Unit.Value;
        }
    }
}
