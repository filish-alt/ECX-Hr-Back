using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Outsource.Request.Command;
using ECX.HR.Application.DTOs.Outsource.Validator;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Handler.Command
{
    public class CreateOutsourceCommandHandler : IRequestHandler<CreateOutsourceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IOutsourceRepository _OutsourceRepository;
        private IMapper _mapper;
        public CreateOutsourceCommandHandler(IOutsourceRepository OutsourceRepository, IMapper mapper)
        {
            _OutsourceRepository = OutsourceRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateOutsourceCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new OutsourceValidator();
            var validationResult = await validator.ValidateAsync(request.OutsourceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var Outsource = _mapper.Map<OutSources>(request.OutsourceDto);
            Outsource.Id = Guid.NewGuid();
            var data = await _OutsourceRepository.Add(Outsource);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
