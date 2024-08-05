using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.PromotionVacancy.Request.Command;
using ECX.HR.Application.DTOs.PromotionVacancy.Validator;
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

namespace ECX.HR.Application.CQRS.PromotionVacancy.Handler.Command
{
    public class CreatePromotionVacancyCommandHandler : IRequestHandler<CreatePromotionVacancyCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IPromotionVacancyRepository _PromotionVacancyRepository;
        private IMapper _mapper;
        public CreatePromotionVacancyCommandHandler(IPromotionVacancyRepository PromotionVacancyRepository, IMapper mapper)
        {
            _PromotionVacancyRepository = PromotionVacancyRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreatePromotionVacancyCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new PromotionVacancyDtoValidator();
            var validationResult =await validator.ValidateAsync(request.PromotionVacancyDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var PromotionVacancy = _mapper.Map<PromotionVacancys>(request.PromotionVacancyDto);
            PromotionVacancy.VacancyId = Guid.NewGuid();
            var data =await _PromotionVacancyRepository.Add(PromotionVacancy);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
