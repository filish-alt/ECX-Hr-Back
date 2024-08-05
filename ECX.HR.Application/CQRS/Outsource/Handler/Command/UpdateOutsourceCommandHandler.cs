using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Outsource.Request.Command;
using ECX.HR.Application.DTOs.Outsource.Validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Handler.Command
{
    public class UpdateOutsourceCommandHandler : IRequestHandler<UpdateOutsourceCommand, Unit>
    {
        private IOutsourceRepository _OutsourceRepository;
        private IMapper _mapper;
        public UpdateOutsourceCommandHandler(IOutsourceRepository OutsourceRepository, IMapper mapper)
        {
            _OutsourceRepository = OutsourceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOutsourceCommand request, CancellationToken cancellationToken)
        {
            var validator = new OutsourceValidator();
            var validationResult = await validator.ValidateAsync(request.OutsourceDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Outsource = await _OutsourceRepository.GetById(request.OutsourceDto.Id);
            _mapper.Map(request.OutsourceDto, Outsource);
            await _OutsourceRepository.Update(Outsource);
            return Unit.Value;
        }
    }
}
