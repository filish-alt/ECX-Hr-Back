using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.MedicalFund.Request.Queries;
using ECX.HR.Application.DTOs.Addresss;

using ECX.HR.Application.DTOs.MedicalFunds;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Handler.Queries
{
    public class GetMedicalFundDetailRequestHandler : IRequestHandler<GetMedicalFundDetailRequest, List<MedicalFundDto>>
    {
        private readonly IMedicalFundRepository _medicalFundRepository;
        private readonly IMapper _mapper;

        public GetMedicalFundDetailRequestHandler(IMedicalFundRepository MedicalFundRepository, IMapper Mapper)
        {
            _medicalFundRepository = MedicalFundRepository;
            _mapper = Mapper;
        }
        public async Task<List<MedicalFundDto>> Handle(GetMedicalFundDetailRequest request, CancellationToken cancellationToken)
        {
            var med = await _medicalFundRepository.GetByEmpId(request.Id);

            if (med == null || med.Any(we => we.Status != 0))
                throw new NotFoundException(nameof(med), request.Id);

            return _mapper.Map<List<MedicalFundDto>>(med);
        }
    }
}
