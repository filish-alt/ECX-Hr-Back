using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.PromotionRelation.Request.Command;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionRelation.Handler.Command
{
    public  class GetFilePromotionCommandHandler : IRequestHandler<GetFilePromotionCommand, byte[]>
    {
        private readonly IPromotionRelationRepository _promotionRelationRepository;
        private readonly IMapper _mapper;

        public GetFilePromotionCommandHandler(IPromotionRelationRepository promotionRelationRepository, IMapper Mapper)
        {
        _promotionRelationRepository = promotionRelationRepository;
            _mapper = Mapper;
        }

        public async Task<byte[]> Handle(GetFilePromotionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming you have an entity representing files in your database
                var fileEntity = await _promotionRelationRepository.GetByPosEmp(request.VacancyId, request.EmpId);
               
                if (fileEntity != null)
                {
                    string base64String = fileEntity.File;
                    byte[] fileData = Convert.FromBase64String(base64String);
                    // Retrieve the file data (byte array) from the database entity
                    // string uniqueFileName = Guid.NewGuid().ToString() + ".pdf";


                    return fileData;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions related to database access
                // Logging, error handling, etc.
            }

            // Return null if the file is not found or an error occurs
            return null;
        }
    }
}
