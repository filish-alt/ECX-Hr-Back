using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.DTOs.MedicalBalance.Validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Handler.Command
{
    public class UpdateMedicalBalanceDtoCommandHandler : IRequestHandler<UpdateMedicalBalance, Unit>
    {
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IMapper _mapper;

        public UpdateMedicalBalanceDtoCommandHandler(IMedicalBalanceRepository medicalBalanceRepository, IMapper mapper)
        {
            _medicalBalanceRepository = medicalBalanceRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMedicalBalance request, CancellationToken cancellationToken)
        {
            var validator = new MedicalBalanceDtoValidators();
            var validationResult = await validator.ValidateAsync(request.MedicalBalanceDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.MedicalBalanceDto.UpdatedDate = DateTime.Now;
            var med = await _medicalBalanceRepository.GetById(request.MedicalBalanceDto.MedicalRequestId);



            _mapper.Map(request.MedicalBalanceDto, med);

            await _medicalBalanceRepository.Update(med);
            return Unit.Value;
        }
    }
}
