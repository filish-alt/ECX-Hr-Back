using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Termination.Request.Command;
using ECX.HR.Application.DTOs.Termination.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Termination.Handler.Command
{
    public class UpdateTerminationCommandHandler : IRequestHandler<UpdateTerminationCommand, Unit>
    {
        private ITerminationRepository _TerminationRepository;
        private IMapper _mapper;
        public UpdateTerminationCommandHandler(ITerminationRepository TerminationRepository, IMapper mapper)
        {
            _TerminationRepository = TerminationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTerminationCommand request, CancellationToken cancellationToken)
        {
            var validator = new TerminationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TerminationDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Termination = await _TerminationRepository.GetById(request.TerminationDto.Id);
            _mapper.Map(request.TerminationDto, Termination);
            await _TerminationRepository.Update(Termination);
            return Unit.Value;
        }
    }
}
