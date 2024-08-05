using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Tax.Request.Command;
using ECX.HR.Application.DTOs.Tax;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.DTOs.Tax.validator;

namespace ECX.HR.Application.CQRS.Tax.Handler.Command
{
    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ITaxRepository _TaxRepository;
        private IMapper _mapper;
        public CreateTaxCommandHandler(ITaxRepository TaxRepository, IMapper mapper)
        {
            _TaxRepository = TaxRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new TaxDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TaxDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var Tax = _mapper.Map<Taxs>(request.TaxDto);
            Tax.Id = Guid.NewGuid();
            var data = await _TaxRepository.Add(Tax);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
