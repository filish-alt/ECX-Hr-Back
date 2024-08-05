using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Allowances.Request.Command;
using ECX.HR.Application.DTOs.Allowances.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowances.Handler.Command
{
    public class CreateAllowanceCommandHandler : IRequestHandler<CreateAllowanceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IAllwoanceRepository _AllowanceRepository;
        private IMapper _mapper;
        public CreateAllowanceCommandHandler(IAllwoanceRepository AllowanceRepository, IMapper mapper)
        {
            _AllowanceRepository = AllowanceRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAllowanceCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new AlowanceValidator();
            var validationResult =await validator.ValidateAsync(request.AllowanceDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var Allowance = _mapper.Map<Domain.Allowances>(request.AllowanceDto);
            Allowance.Id = Guid.NewGuid();
            var allowance = Allowance.Id;
            var data =await _AllowanceRepository.Add(Allowance);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)allowance;
            return response;
        }
    }
}
