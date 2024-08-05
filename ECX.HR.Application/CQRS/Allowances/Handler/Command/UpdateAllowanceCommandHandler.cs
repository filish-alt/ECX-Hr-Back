using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Allowance.Request.Command;

using ECX.HR.Application.DTOs.Allowances.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowance.Handler.Command
{
    public class UpdateAllowanceCommandHandler : IRequestHandler<UpdateAllowanceCommand, Unit>
    {
        private IAllwoanceRepository _AllowanceRepository;
        private IMapper _mapper;
        public UpdateAllowanceCommandHandler(IAllwoanceRepository AllowanceRepository, IMapper mapper)
        {
            _AllowanceRepository = AllowanceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAllowanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new AlowanceValidator();
            var validationResult = await validator.ValidateAsync(request.AllowanceDto);
           
           
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var allowance = await _AllowanceRepository.GetById(request.AllowanceDto.Id);
            _mapper.Map(request.AllowanceDto, allowance);
            await _AllowanceRepository.Update(allowance);
            return Unit.Value;
        }
    }
}
