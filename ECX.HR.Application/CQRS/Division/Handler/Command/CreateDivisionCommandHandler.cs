using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Division.Request.Command;
using ECX.HR.Application.DTOs.Division;
using ECX.HR.Application.DTOs.Division.Validator;

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

namespace ECX.HR.Application.CQRS.Division.Handler.Command
{
    public class CreateDivisionCommandHandler : IRequestHandler<CreateDivisionCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IDivisionRepository _DivisionRepository;
        private IMapper _mapper;
        public CreateDivisionCommandHandler(IDivisionRepository DivisionRepository, IMapper mapper)
        {
            _DivisionRepository = DivisionRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateDivisionCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new DivisionValidator();
            var validationResult =await validator.ValidateAsync(request.DivisionDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var division = _mapper.Map<Divisions>(request.DivisionDto);
            division.DivisionId = Guid.NewGuid();
            var data =await _DivisionRepository.Add(division);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
