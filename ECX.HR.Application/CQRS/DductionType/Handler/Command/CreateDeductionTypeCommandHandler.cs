using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.DTOs.DeductionType.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ECX.HR.Application.CQRS.DductionType.Handler.Command
{
   
    public class CreateDeductionTypeCommandHandler : IRequestHandler<CreateDeductionTypeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
  
        private readonly IDeductionTypeRepository _deductionTypeRepository;
        private IMapper _mapper;
        public CreateDeductionTypeCommandHandler(IDeductionTypeRepository DeductionTypeRepository, IMapper mapper)
        {
           _deductionTypeRepository = DeductionTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateDeductionTypeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new DeductionTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.deductionTypeDto);
  

                if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }


               
            var DeductionType = _mapper.Map<DeductionTypes>(request.deductionTypeDto);
            DeductionType.Id = Guid.NewGuid();
            var bra = DeductionType.Id;
            var data = await _deductionTypeRepository.Add(DeductionType);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)bra;
            return response;

        }
    }
}
