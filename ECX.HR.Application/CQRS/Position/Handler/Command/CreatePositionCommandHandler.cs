using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Position.Request.Command;
using ECX.HR.Application.DTOs.Positions.Validator;
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

namespace ECX.HR.Application.CQRS.Position.Handler.Command
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IPositionRepository _PositionRepository;
        private IMapper _mapper;
        public CreatePositionCommandHandler(IPositionRepository PositionRepository, IMapper mapper)
        {
            _PositionRepository = PositionRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new PositionDtoValidators();
            var validationResult =await validator.ValidateAsync(request.PositionDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var position = _mapper.Map<Positions>(request.PositionDto);
            position.PositionId = Guid.NewGuid();
            var data =await _PositionRepository.Add(position);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
