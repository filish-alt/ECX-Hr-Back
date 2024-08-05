using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Division.Request.Command;
using ECX.HR.Application.DTOs.Division.Validator;

using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Division.Handler.Command
{
    public class UpdateDivisionCommandHandler : IRequestHandler<UpdateDivisionCommand, Unit>
    {
        private IDivisionRepository _DivisionRepository;
        private IMapper _mapper;
        public UpdateDivisionCommandHandler(IDivisionRepository DivisionRepository, IMapper mapper)
        {
            _DivisionRepository = DivisionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDivisionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DivisionValidator();
            var validationResult = await validator.ValidateAsync(request.DivisionDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Division = await _DivisionRepository.GetById(request.DivisionDto.DivisionId);
           _mapper.Map(request.DivisionDto,Division);
            
            await _DivisionRepository.Update(Division);
            return Unit.Value;
        }
    }
}
