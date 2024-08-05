using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AllowanceType.Request.Command;
using ECX.HR.Application.DTOs.AllowanceType;
using ECX.HR.Application.DTOs.AllowanceType.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Exceptions;

namespace ECX.HR.Application.CQRS.AllowanceType.Handler.Command
{
    public class CreateAllowanceTypeCommandHandler : IRequestHandler<CreateAllowanceTypeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IAllowanceTypeRepository _AllowanceTypeRepository;
        private IMapper _mapper;
        public CreateAllowanceTypeCommandHandler(IAllowanceTypeRepository AllowanceTypeRepository, IMapper mapper)
        {
            _AllowanceTypeRepository = AllowanceTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAllowanceTypeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new AllowanceTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AllowanceTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var AllowanceType = _mapper.Map<AllowanceTypes>(request.AllowanceTypeDto);
            AllowanceType.Id = Guid.NewGuid();
            var add = AllowanceType.Id;
            var data = await _AllowanceTypeRepository.Add(AllowanceType);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)add;
            return response;
        }
    }
}
