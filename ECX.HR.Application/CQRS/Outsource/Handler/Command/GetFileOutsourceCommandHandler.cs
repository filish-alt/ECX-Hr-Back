using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveRequest.Request.Command;
using ECX.HR.Application.CQRS.Outsource.Request.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Handler.Command
{
    public class GetFileOutsourceCommandHandler : IRequestHandler<GetFileOutsourceCommand, byte[]>
    {

        private readonly IOutsourceRepository _outsourceRepository;
        private readonly IMapper _mapper;

        public GetFileOutsourceCommandHandler(IOutsourceRepository outsourceRepository, IMapper Mapper)
        {

         _outsourceRepository = outsourceRepository;
            _mapper = Mapper;

        }

        public async Task<byte[]> Handle(GetFileOutsourceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming you have an entity representing files in your database
                var fileEntity = await _outsourceRepository.GetById(request.Outsourceid);

                if (fileEntity != null)
                {
                    string base64String = fileEntity.File;
                    byte[] fileData = Convert.FromBase64String(base64String);
               


                    return fileData;
                }
            }
            catch (Exception ex)
            {
   
            }

            return null;
        }
    }
}
