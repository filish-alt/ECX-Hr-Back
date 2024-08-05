using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.DepositAutorization.Request.Command;

using ECX.HR.Application.DTOs.DepositAutorizations.Validator;
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

namespace ECX.HR.Application.CQRS.DepositAutorization.Handler.Command
{
    public class CreateDepositAutorizationCommandHandler : IRequestHandler<CreateDepositAutorizationCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IDepositAutorizationRepository _DepositAutorizationRepository;
        private IMapper _mapper;
        public CreateDepositAutorizationCommandHandler(IDepositAutorizationRepository DepositAutorizationRepository, IMapper mapper)
        {
            _DepositAutorizationRepository = DepositAutorizationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateDepositAutorizationCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new DepositAutorizationDtoValidator();
            var validationResult =await validator.ValidateAsync(request.DepositAutorizationDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var depositAutorization = _mapper.Map<DepositAutorizations>(request.DepositAutorizationDto);
            depositAutorization.Id = Guid.NewGuid();
            var data =await _DepositAutorizationRepository.Add(depositAutorization);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
