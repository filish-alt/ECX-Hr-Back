using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Holiday.Request.Command;
using ECX.HR.Application.DTOs.Holiday.Validators;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Handler.Command
{
    public class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommand, Unit>
    {
        private IHolidayRepository _HolidayRepository;
        private IMapper _mapper;
        public UpdateHolidayCommandHandler(IHolidayRepository HolidayRepository, IMapper mapper)
        {
            _HolidayRepository = HolidayRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHolidayCommand request, CancellationToken cancellationToken)
        {
            var validator = new HolidayDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HolidayDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Holiday = await _HolidayRepository.GetById(request.HolidayDto.Id);
            _mapper.Map(request.HolidayDto, Holiday);
            await _HolidayRepository.Update(Holiday);
            return Unit.Value;
        }
    }
}
