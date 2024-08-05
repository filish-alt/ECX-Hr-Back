using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.CQRS.Deduction.Request.Command;
using ECX.HR.Application.DTOs.Deduction.Validator;
using ECX.HR.Application.DTOs.Deduction.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Handler.Command
{
    public class CreateDeductionCommandHandler : IRequestHandler<CreateDeductionCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;

     
        private readonly IDeductionRepository _deductionRepository;
        private IMapper _mapper;
        public CreateDeductionCommandHandler(IDeductionRepository DeductionRepository, IMapper mapper)
        {
         
           _deductionRepository = DeductionRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateDeductionCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new DeductionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.deductionDto);


            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            
            var Deduction = _mapper.Map<Deductions>(request.deductionDto);
            Deduction.Id = Guid.NewGuid();
            var bra = Deduction.Id;

            var data = await _deductionRepository.Add(Deduction);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)bra;
            return response;

        }
    }
}
