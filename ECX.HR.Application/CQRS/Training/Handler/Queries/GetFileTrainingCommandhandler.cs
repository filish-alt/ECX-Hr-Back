using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Training.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.training.Handler.Command
{
    public class GetFileTrainingCommandhandler : IRequestHandler<GetTrainingFileCommand, byte[]>
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        public GetFileTrainingCommandhandler(ITrainingRepository trainingRepository, IMapper Mapper)
        {
          _trainingRepository = trainingRepository;
            _mapper = Mapper;

        }

        public async Task<byte[]> Handle(GetTrainingFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming you have an entity representing files in your database
                var fileEntity = await _trainingRepository.GetById(request.Id);
               
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
