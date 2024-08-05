using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Holiday.Request.Command;
using ECX.HR.Application.DTOs.Holiday.Validators;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Handler.Command
{
    public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IHolidayRepository _HolidayRepository;
        private IMapper _mapper;
        public CreateHolidayCommandHandler(IHolidayRepository HolidayRepository, IMapper mapper)
        {
            _HolidayRepository = HolidayRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new HolidayDtoValidator();
            var validationResult =await validator.ValidateAsync(request.HolidayDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var Holiday = _mapper.Map<Holidays>(request.HolidayDto);
            Holiday.Id = Guid.NewGuid();
            Holiday.Date = request.HolidayDto.Date.AddDays(1);
          
            var data =await _HolidayRepository.Add(Holiday);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
