using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Level.Request.Command;
using ECX.HR.Application.DTOs.Levels.Validator;
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

namespace ECX.HR.Application.CQRS.Level.Handler.Command
{
    public class CreateLevelCommandHandler : IRequestHandler<CreateLevelCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ILevelRepository _LevelRepository;
        private IMapper _mapper;
        public CreateLevelCommandHandler(ILevelRepository LevelRepository, IMapper mapper)
        {
            _LevelRepository = LevelRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLevelCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new LevelDtoValidators();
            var validationResult =await validator.ValidateAsync(request.LevelDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var level = _mapper.Map<Levels>(request.LevelDto);
            level.LevelId = Guid.NewGuid();
            var data =await _LevelRepository.Add(level);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
