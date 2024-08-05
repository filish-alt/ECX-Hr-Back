using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.OverTime.Request.Command;
using ECX.HR.Application.DTOs.OverTime.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OverTime.Handler.Command
{
    public class CreateOverTimeCommandHandler : IRequestHandler<CreateOverTimeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IOverTimeRepository _OverTimeRepository;
        private IMapper _mapper;
        public CreateOverTimeCommandHandler(IOverTimeRepository OverTimeRepository, IMapper mapper)
        {
            this.OverTimeRepository = OverTimeRepository;
            _mapper = mapper;
        }

        public IOverTimeRepository OverTimeRepository { get => _OverTimeRepository; set => _OverTimeRepository = value; }

        public async Task<BaseCommandResponse> Handle(CreateOverTimeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new OverTimeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OverTimeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var OverTime = _mapper.Map<OverTimes>(request.OverTimeDto);
            OverTime.Id = Guid.NewGuid();
            OverTime.EmpId = request.OverTimeDto.EmpId;
            OverTime.OTDay = 0;
            OverTime.OTNight = 0;
            OverTime.OTWeekend = 0;
            OverTime.OTHoliday = 0;

            var data = await OverTimeRepository.Add(OverTime);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
