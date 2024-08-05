using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.DepositAutorization.Request.Command;

using ECX.HR.Application.DTOs.DepositAutorizations.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.DepositAutorization.Handler.Command
{
    public class UpdateDepositAutorizationCommandHandler : IRequestHandler<UpdateDepositAutorizationCommand, Unit>
    {
        private IDepositAutorizationRepository _DepositAutorizationRepository;
        private IMapper _mapper;
        public UpdateDepositAutorizationCommandHandler(IDepositAutorizationRepository DepositAutorizationRepository, IMapper mapper)
        {
            _DepositAutorizationRepository = DepositAutorizationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDepositAutorizationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DepositAutorizationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DepositAutorizationDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var DepositAutorization = await _DepositAutorizationRepository.GetById(request.DepositAutorizationDto.Id);
            _mapper.Map(request.DepositAutorizationDto, DepositAutorization);
            await _DepositAutorizationRepository.Update(DepositAutorization);
            return Unit.Value;
        }
    }
}
