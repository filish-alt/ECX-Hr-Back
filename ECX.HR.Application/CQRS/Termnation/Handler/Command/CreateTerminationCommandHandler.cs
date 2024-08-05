using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Termination.Request.Command;
using ECX.HR.Application.DTOs.Termination.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Termination.Handler.Command
{
    public class CreateTerminationCommandHandler : IRequestHandler<CreateTerminationCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ITerminationRepository _TerminationRepository;
        private IMapper _mapper;
        public CreateTerminationCommandHandler(ITerminationRepository TerminationRepository, IMapper mapper)
        {
            _TerminationRepository = TerminationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateTerminationCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new TerminationDtoValidator();
            var validationResult =await validator.ValidateAsync(request.TerminationDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var Termination = _mapper.Map<Terminations>(request.TerminationDto);
            Termination.Id = Guid.NewGuid();
            var data =await _TerminationRepository.Add(Termination);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
