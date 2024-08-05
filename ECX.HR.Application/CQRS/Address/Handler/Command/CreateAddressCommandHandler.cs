using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.DTOs.Address.Validator;


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

namespace ECX.HR.Application.CQRS.Address.Handler.Command
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IAdressRepository _AddressRepository;
        private IMapper _mapper;
        public CreateAddressCommandHandler(IAdressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new AddressDtoValidator();
            var validationResult =await validator.ValidateAsync(request.AdressDetailDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var Address = _mapper.Map<Adress>(request.AdressDetailDto);
            Address.Id = Guid.NewGuid();
            var add = Address.Id;
            var data =await _AddressRepository.Add(Address);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)add;
            return response;
        }
    }
}
