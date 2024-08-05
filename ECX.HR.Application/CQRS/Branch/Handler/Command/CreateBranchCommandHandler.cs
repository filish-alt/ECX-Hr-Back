using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Branch.Request.Command;

using ECX.HR.Application.DTOs.Branchs.Validator;
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

namespace ECX.HR.Application.CQRS.Branch.Handler.Command
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IBranchRepository _BranchRepository;
        private IMapper _mapper;
        public CreateBranchCommandHandler(IBranchRepository BranchRepository, IMapper mapper)
        {
            _BranchRepository = BranchRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new BranchValidator();
            var validationResult =await validator.ValidateAsync(request.BranchDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var branch = _mapper.Map<Branches>(request.BranchDto);
            branch.Id = Guid.NewGuid();
            var bra = branch.Id;
            var data =await _BranchRepository.Add(branch);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)bra;
            return response;

        }
    }
}
