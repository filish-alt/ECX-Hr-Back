using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.WorkExperience.Request.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.WorkExperience.Handler.Command
{
    public class GetWorkExperienceFileCommandhandler : IRequestHandler<GetWorkExperienceFileCommand, byte[]>
    {
        private readonly IWorkExperienceRepository _WorkExperienceRepository;
        private readonly IMapper _mapper;

        public GetWorkExperienceFileCommandhandler(IWorkExperienceRepository WorkExperienceRepository, IMapper Mapper)
        {
          _WorkExperienceRepository = WorkExperienceRepository;
            _mapper = Mapper;

        }

        public async Task<byte[]> Handle(GetWorkExperienceFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming you have an entity representing files in your database
                var fileEntity = await _WorkExperienceRepository.GetById(request.Id);
               
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
