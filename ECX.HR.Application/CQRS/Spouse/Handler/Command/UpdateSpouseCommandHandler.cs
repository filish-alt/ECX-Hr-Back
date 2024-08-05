using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Spouse.Request.Command;

using ECX.HR.Application.DTOs.Spouses.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Handler.Command
{
    public class UpdateSpouseCommandHandler : IRequestHandler<UpdateSpouseCommand, Unit>
    {
        private ISpouseRepository _SpouseRepository;
        private IMapper _mapper;
        public UpdateSpouseCommandHandler(ISpouseRepository SpouseRepository, IMapper mapper)
        {
            _SpouseRepository = SpouseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSpouseCommand request, CancellationToken cancellationToken)
        {
            var validator = new SpouseValidator();
            var validationResult = await validator.ValidateAsync(request.SpouseDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Spouse = await _SpouseRepository.GetById(request.SpouseDto.Id);
            _mapper.Map(request.SpouseDto, Spouse);
            await _SpouseRepository.Update(Spouse);
            return Unit.Value;
        }
    }
}
