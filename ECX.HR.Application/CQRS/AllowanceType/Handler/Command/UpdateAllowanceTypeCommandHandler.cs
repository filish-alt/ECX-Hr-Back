using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AllowanceType.Request.Command;
using ECX.HR.Application.DTOs.AllowanceType.Validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AllowanceType.Handler.Command
{
    public class UpdateAllowanceTypeCommandHandler : IRequestHandler<UpdateAllowanceTypeCommand, Unit>
    {
        private IAllowanceTypeRepository _AllowanceTypeRepository;
        private IMapper _mapper;

        public UpdateAllowanceTypeCommandHandler(IAllowanceTypeRepository AllowanceTypeRepository, IMapper mapper)
        {
            _AllowanceTypeRepository = AllowanceTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAllowanceTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new AllowanceTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AllowanceTypeDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.AllowanceTypeDto.UpdatedDate = DateTime.Now;
            var AllowanceType = await _AllowanceTypeRepository.GetById(request.AllowanceTypeDto.Id);



            _mapper.Map(request.AllowanceTypeDto, AllowanceType);

            await _AllowanceTypeRepository.Update(AllowanceType);
            return Unit.Value;
        }
    }
}
