using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Salary.Request.Command;
using ECX.HR.Application.DTOs.Salary.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Salary.Handler.Command
{
    public class UpdateSalaryCommandHandler : IRequestHandler<UpdateSalaryCommand, Unit>
    {
        private ISalaryRepository _SalaryRepository;
        private IMapper _mapper;
        public UpdateSalaryCommandHandler(ISalaryRepository SalaryRepository, IMapper mapper)
        {
            _SalaryRepository = SalaryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
        {
            var validator = new SalaryDtoValidators();
            var validationResult = await validator.ValidateAsync(request.SalaryDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Salary = await _SalaryRepository.GetById(request.SalaryDto.Id);
            _mapper.Map(request.SalaryDto, Salary);
            await _SalaryRepository.Update(Salary);
            return Unit.Value;
        }
    }
}
