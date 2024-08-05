using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Command;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Command;
using ECX.HR.Application.DTOs.PromotionRelation.Validator;
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


namespace ECX.HR.Application.CQRS.PromotionRelation.Handler.Command
{
    public class CreatePromotionRelationCommandHandler : IRequestHandler<CreatePromotionRelationCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IPromotionRelationRepository _PromotionRelationRepository;
        private IMapper _mapper;
        public CreatePromotionRelationCommandHandler(IPromotionRelationRepository PromotionRelationRepository, IMapper mapper)
        {
            _PromotionRelationRepository = PromotionRelationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreatePromotionRelationCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new PromotionRelationDtoValidator();
            var validationResult =await validator.ValidateAsync(request.PromotionRelationDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var PromotionRelation = _mapper.Map<PromotionRelations>(request.PromotionRelationDto);
            PromotionRelation.Id = Guid.NewGuid();
            var data =await _PromotionRelationRepository.Add(PromotionRelation);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
