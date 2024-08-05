using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.MedicalFund.Request.Queries;

using ECX.HR.Application.DTOs.Addresss;
using ECX.HR.Application.DTOs.MedicalFunds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Handler.Queries
{
    public class GetMedicalFundListRequestHandler : IRequestHandler<GetMedicalFundListRequest, List<MedicalFundDto>>
    {
        private readonly IMedicalFundRepository _medicalfundRepository;
        private readonly IMapper _mapper;

        public GetMedicalFundListRequestHandler()
        {
        }

        public GetMedicalFundListRequestHandler(IMedicalFundRepository medicalfundRepository, IMapper Mapper)
        {
            _medicalfundRepository = medicalfundRepository;
            _mapper = Mapper;
        }
        public async Task<List<MedicalFundDto>> Handle(GetMedicalFundListRequest request, CancellationToken cancellationToken)
        {
            var med = await _medicalfundRepository.GetAll();

            var meds = med.Where(med => med.Status == 0).ToList();

            return _mapper.Map<List<MedicalFundDto>>(meds);
        }
    }
}
