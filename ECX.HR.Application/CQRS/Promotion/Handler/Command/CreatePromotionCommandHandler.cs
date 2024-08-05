using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Promotion.Request.Command;
using ECX.HR.Application.CQRS.Promotion.Request.Command;
using ECX.HR.Application.DTOs.Promotions.Validator;
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

namespace ECX.HR.Application.CQRS.Promotion.Handler.Command
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IPromotionRepository _PromotionRepository;
        private IMapper _mapper;
        public CreatePromotionCommandHandler(IPromotionRepository PromotionRepository, IMapper mapper)
        {
            _PromotionRepository = PromotionRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new PromotionDtoValidators();
            var validationResult =await validator.ValidateAsync(request.PromotionDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var Promotion = _mapper.Map<Promotions>(request.PromotionDto);
            Promotion.Id = Guid.NewGuid();
            var data =await _PromotionRepository.Add(Promotion);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
