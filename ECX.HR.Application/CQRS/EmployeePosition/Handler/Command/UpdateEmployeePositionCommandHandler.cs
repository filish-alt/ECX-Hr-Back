using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Command;

using ECX.HR.Application.DTOs.EmployeePositions.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeePosition.Handler.Command
{
    public class UpdateEmployeePositionCommandHandler : IRequestHandler<UpdateEmployeePositionCommand, Unit>
    {
        private IEmployeePositionRepository _EmployeePositionRepository;
        private IMapper _mapper;
        public UpdateEmployeePositionCommandHandler(IEmployeePositionRepository EmployeePositionRepository, IMapper mapper)
        {
            _EmployeePositionRepository = EmployeePositionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            var validator = new EmployeePositionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeePositionDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EmployeePosition = await _EmployeePositionRepository.GetById(request.EmployeePositionDto.Id);
            _mapper.Map(request.EmployeePositionDto, EmployeePosition);
            await _EmployeePositionRepository.Update(EmployeePosition);
            return Unit.Value;
        }
    }
}
