using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Salary.Request.Command;
using ECX.HR.Application.DTOs.Salary;
using ECX.HR.Application.DTOs.Salary.Validator;

using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Salary.Handler.Command
{
    public class CreateSalaryCommandHandler : IRequestHandler<CreateSalaryCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ISalaryRepository _SalaryRepository;
        private IMapper _mapper;
        public CreateSalaryCommandHandler(ISalaryRepository SalaryRepository, IMapper mapper)
        {
            _SalaryRepository = SalaryRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateSalaryCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new SalaryDtoValidators();
            var validationResult =await validator.ValidateAsync(request.SalaryDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var salary = _mapper.Map<SalaryTypes>(request.SalaryDto);
            salary.Id = Guid.NewGuid();
            var data =await _SalaryRepository.Add(salary);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
